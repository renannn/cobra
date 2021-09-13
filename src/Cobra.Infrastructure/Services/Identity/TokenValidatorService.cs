using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Cobra.Common.GuardToolkit;
using Cobra.Entities.Administration;
using Cobra.SharedKernel.Enums;
using Cobra.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Cobra.Infrastructure.Services.Identity
{
    public interface ITokenValidatorService
    {
        Task ValidateAsync(TokenValidatedContext context);
    }

    public class TokenValidatorService : ITokenValidatorService
    {
        private readonly IRepository<Guid,User> _usersService;
        private readonly ISecurityService _securityService;

        public TokenValidatorService(IRepository<Guid, User> usersService,ISecurityService securityService)
        {
            _usersService = usersService;
            _securityService = securityService;
        }

        public async Task ValidateAsync(TokenValidatedContext context)
        {
            var claimsIdentity = context.Principal.Identity as ClaimsIdentity;
            if (claimsIdentity?.Claims == null || !claimsIdentity.Claims.Any())
            {
                context.Fail("This is not our issued token. It has no claims.");
                return;
            }

            var userIdString = claimsIdentity.FindFirst("id").Value;
            if (!Guid.TryParse(userIdString, out Guid userId))
            {
                context.Fail("This is not our issued token. It has no user-id.");
                return;
            }

            var user = await _usersService.ReadRepository.GetByIdAsync(userId);
            if (user == null || user.IsDisabled)
            {
                // user has changed his/her password/roles/stat/IsActive
                context.Fail("This token is expired. Please login again.");
            }

            if (user.BlockedState == BlockedState.IsBlocked)
            {
                context.Fail("Sua conta foi bloqueada.");
            }

            if (!(context.SecurityToken is JwtSecurityToken accessToken) || string.IsNullOrWhiteSpace(accessToken.RawData) ||
                !await IsValidTokenAsync(user,accessToken.RawData))
            {
                context.Fail("This token is not in our database.");
                return;
            }

            //await _usersService.UpdateUserLastActivityDateAsync(userId);
        }

        private async Task<bool> IsValidTokenAsync(User user, string accessToken)
        {
            var accessTokenHash = _securityService.GetSha256Hash(accessToken);
            var userToken = user.Tokens.FirstOrDefault(
                x => x.AccessTokenHash == accessTokenHash);
            return userToken?.AccessTokenExpiresDateTime >= DateTime.Now ;
        }
    }
}