using Cobra.Common;
using Cobra.Common.IdentityToolkit;
using Cobra.Infrastructure.Services.Contracts.Identity;
using Cobra.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Cobra.Admin.Areas.Admin.Pages.User;

[Area(AreaConstants.IdentityArea)]
[Authorize(Roles = "Admin")]
public class SearchModel : PageModel
{
    private const int DefaultPageSize = 10;

    private readonly IApplicationRoleManager _roleManager;
    private readonly IApplicationUserManager _userManager;

    public SearchModel(IApplicationUserManager userManager, IApplicationRoleManager roleManager)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
    }

    public PagedUsersListViewModel PModel { get; set; }

    public async Task OnGetAsync(int? page = 1, string field = "Id", SortOrder order = SortOrder.Ascending)
    {
        PModel = await _userManager.GetPagedUsersListAsync(
              pageNumber: page.Value - 1,
              recordsPerPage: DefaultPageSize,
              sortByField: field,
              sortOrder: order,
              showAllUsers: true);

        PModel.Paging.CurrentPage = page.Value;
        PModel.Paging.ItemsPerPage = DefaultPageSize;
        PModel.Paging.ShowFirstLast = true;
    }

    public async Task OnPostAsync(SearchUsersViewModel model)
    {
        var pagedUsersList = await _userManager.GetPagedUsersListAsync(
              model: model,
              pageNumber: 0);

        pagedUsersList.Paging.CurrentPage = 1;
        pagedUsersList.Paging.ItemsPerPage = model.MaxNumberOfRows;
        pagedUsersList.Paging.ShowFirstLast = true;

        PModel = pagedUsersList;
    }

    [AjaxOnly]
    public async Task<IActionResult> OnPostChangeUserStat(Guid userId, bool activate)
    {
        Entities.Administration.User thisUser = null;
        var result = await _userManager.UpdateUserAndSecurityStampAsync(
            userId, user =>
            {
                user.IsActive = activate;
                thisUser = user;
            });
        if (!result.Succeeded)
        {
            return BadRequest(error: result.DumpErrors(useHtmlNewLine: true));
        }

        return await ReturnUserCardPartialView(thisUser);
    }

    [AjaxOnly]
    public async Task<IActionResult> OnPostActivateUserEmailStat(Guid userId)
    {
        Entities.Administration.User thisUser = null;
        var result = await _userManager.UpdateUserAndSecurityStampAsync(
            userId, user =>
            {
                user.EmailConfirmed = true;
                thisUser = user;
            });
        if (!result.Succeeded)
        {
            return BadRequest(error: result.DumpErrors(useHtmlNewLine: true));
        }

        return await ReturnUserCardPartialView(thisUser);
    }

    [AjaxOnly]
    public async Task<IActionResult> OnPostChangeUserTwoFactorAuthenticationStat(Guid userId, bool activate)
    {
        Entities.Administration.User thisUser = null;
        var result = await _userManager.UpdateUserAndSecurityStampAsync(
            userId, user =>
            {
                user.TwoFactorEnabled = activate;
                thisUser = user;
            });
        if (!result.Succeeded)
        {
            return BadRequest(error: result.DumpErrors(useHtmlNewLine: true));
        }

        return await ReturnUserCardPartialView(thisUser);
    }

    [AjaxOnly]
    public async Task<IActionResult> OnPostEndUserLockout(Guid userId)
    {
        Entities.Administration.User thisUser = null;
        var result = await _userManager.UpdateUserAndSecurityStampAsync(
            userId, user =>
            {
                user.LockoutEnd = null;
                thisUser = user;
            });
        if (!result.Succeeded)
        {
            return BadRequest(error: result.DumpErrors(useHtmlNewLine: true));
        }

        return await ReturnUserCardPartialView(thisUser);
    }

    [AjaxOnly]
    public async Task<IActionResult> ChangeUserLockoutMode(Guid userId, bool activate)
    {
        Entities.Administration.User thisUser = null;
        var result = await _userManager.UpdateUserAndSecurityStampAsync(
            userId, user =>
            {
                user.LockoutEnabled = activate;
                thisUser = user;
            });
        if (!result.Succeeded)
        {
            return BadRequest(error: result.DumpErrors(useHtmlNewLine: true));
        }

        return await ReturnUserCardPartialView(thisUser);
    }

    [AjaxOnly]
    public async Task<IActionResult> OnPostChangeUserRoles(Guid userId, Guid[] roleIds)
    {
        Entities.Administration.User thisUser = null;
        var result = await _userManager.AddOrUpdateUserRolesAsync(
            userId, roleIds, user => thisUser = user);
        if (!result.Succeeded)
        {
            return BadRequest(error: result.DumpErrors(useHtmlNewLine: true));
        }

        return await ReturnUserCardPartialView(thisUser);
    }

    private async Task<IActionResult> ReturnUserCardPartialView(Entities.Administration.User thisUser)
    {
        var roles = await _roleManager.GetAllCustomRolesAsync();
        return Partial("~/Areas/Admin/Pages/User/_UserCardItem.cshtml",
            new UserCardItemViewModel
            {
                User = thisUser,
                ShowAdminParts = true,
                Roles = roles,
                ActiveTab = UserCardItemActiveTab.UserAdmin
            });
    }
}
