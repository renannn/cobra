﻿using Cobra.Common;
using Cobra.Entities.Administration;
using Cobra.Infrastructure.Data;
using Cobra.Infrastructure.Services.Contracts.Identity;
using Cobra.Models.Identity;
using Cobra.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cobra.Infrastructure.Services.Identity
{
    /// <summary>
    /// More info: http://www.dotnettips.info/post/2578
    /// </summary>
    public class ApplicationRoleManager :
        RoleManager<Role>,
        IApplicationRoleManager
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUnitOfWork _uow;
        private readonly DbSet<User> _users;

        public ApplicationRoleManager(
            IApplicationRoleStore store,
            IEnumerable<IRoleValidator<Role>> roleValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            ILogger<ApplicationRoleManager> logger,
            IHttpContextAccessor contextAccessor,
            IUnitOfWork uow) :
            base((RoleStore<Role, AppDbContext, Guid, UserRole, RoleClaim>)store, roleValidators, keyNormalizer, errors, logger)
        {
            _contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _users = _uow.Set<User>();
        }

        #region BaseClass

        #endregion

        #region CustomMethods

        public IList<Role> FindCurrentUserRoles()
        {
            var userId = getCurrentUserId();
            return FindUserRoles(userId);
        }

        public IList<Role> FindUserRoles(Guid userId)
        {
            var userRolesQuery = from role in Roles
                                 from user in role.Users
                                 where user.UserId == userId
                                 select role;

            return userRolesQuery.OrderBy(x => x.Name).ToList();
        }

        public Task<List<Role>> GetAllCustomRolesAsync()
        {
            return Roles.ToListAsync();
        }

        public IList<RoleAndUsersCountViewModel> GetAllCustomRolesAndUsersCountList()
        {
            return Roles.Select(role =>
                                    new RoleAndUsersCountViewModel
                                    {
                                        Role = role,
                                        UsersCount = role.Users.Count()
                                    }).ToList();
        }

        public async Task<PagedUsersListViewModel> GetPagedApplicationUsersInRoleListAsync(
                Guid roleId,
                int pageNumber, int recordsPerPage,
                string sortByField, SortOrder sortOrder,
                bool showAllUsers)
        {
            var skipRecords = pageNumber * recordsPerPage;

            var roleUserIdsQuery = from role in Roles
                                   where role.Id == roleId
                                   from user in role.Users
                                   select user.UserId;
            var query = _users.Include(user => user.Roles)
                              .Where(user => roleUserIdsQuery.Contains(user.Id))
                         .AsNoTracking();

            if (!showAllUsers)
            {
                query = query.Where(x => !x.IsDisabled);
            }

            switch (sortByField)
            {
                case nameof(User.Id):
                    query = sortOrder == SortOrder.Descending ? query.OrderByDescending(x => x.Id) : query.OrderBy(x => x.Id);
                    break;
                default:
                    query = sortOrder == SortOrder.Descending ? query.OrderByDescending(x => x.Id) : query.OrderBy(x => x.Id);
                    break;
            }

            return new PagedUsersListViewModel
            {
                Paging =
                {
                    TotalItems = await query.CountAsync()
                },
                Users = await query.Skip(skipRecords).Take(recordsPerPage).ToListAsync(),
                Roles = await Roles.ToListAsync()
            };
        }

        public IList<User> GetApplicationUsersInRole(string roleName)
        {
            var roleUserIdsQuery = from role in Roles
                                   where role.Name == roleName
                                   from user in role.Users
                                   select user.UserId;
            return _users.Where(applicationUser => roleUserIdsQuery.Contains(applicationUser.Id))
                         .ToList();
        }

        public IList<Role> GetRolesForCurrentUser()
        {
            var userId = getCurrentUserId();
            return GetRolesForUser(userId);
        }

        public IList<Role> GetRolesForUser(Guid userId)
        {
            var roles = FindUserRoles(userId);
            if (roles == null || !roles.Any())
            {
                return new List<Role>();
            }

            return roles.ToList();
        }

        public IList<UserRole> GetUserRolesInRole(string roleName)
        {
            return Roles.Where(role => role.Name == roleName)
                             .SelectMany(role => role.Users)
                             .ToList();
        }

        public bool IsCurrentUserInRole(string roleName)
        {
            var userId = getCurrentUserId();
            return IsUserInRole(userId, roleName);
        }

        public bool IsUserInRole(Guid userId, string roleName)
        {
            var userRolesQuery = from role in Roles
                                 where role.Name == roleName
                                 from user in role.Users
                                 where user.UserId == userId
                                 select role;
            var userRole = userRolesQuery.FirstOrDefault();
            return userRole != null;
        }

        public Task<Role> FindRoleIncludeRoleClaimsAsync(Guid roleId)
        {
            return Roles.Include(x => x.Claims).FirstOrDefaultAsync(x => x.Id == roleId);
        }

        public async Task<IdentityResult> AddOrUpdateRoleClaimsAsync(
            Guid roleId,
            string roleClaimType,
            IList<string> selectedRoleClaimValues)
        {
            var role = await FindRoleIncludeRoleClaimsAsync(roleId);
            if (role == null)
            {
                return IdentityResult.Failed(new IdentityError
                {
                    Code = "RoleNotFound",
                    Description = "A regra não foi econtrada."
                });
            }

            var currentRoleClaimValues = role.Claims.Where(roleClaim => roleClaim.ClaimType == roleClaimType)
                                                    .Select(roleClaim => roleClaim.ClaimValue)
                                                    .ToList();

            if (selectedRoleClaimValues == null)
            {
                selectedRoleClaimValues = new List<string>();
            }
            var newClaimValuesToAdd = selectedRoleClaimValues.Except(currentRoleClaimValues).ToList();
            foreach (var claimValue in newClaimValuesToAdd)
            {
                role.Claims.Add(new RoleClaim
                {
                    RoleId = role.Id,
                    ClaimType = roleClaimType,
                    ClaimValue = claimValue
                });
            }

            var removedClaimValues = currentRoleClaimValues.Except(selectedRoleClaimValues).ToList();
            foreach (var claimValue in removedClaimValues)
            {
                var roleClaim = role.Claims.SingleOrDefault(rc => rc.ClaimValue == claimValue &&
                                                                  rc.ClaimType == roleClaimType);
                if (roleClaim != null)
                {
                    role.Claims.Remove(roleClaim);
                }
            }

            return await UpdateAsync(role);
        }

        private Guid getCurrentUserId() => new(_contextAccessor.HttpContext.User.Identity.GetUserId<string>());

        #endregion
    }
}
