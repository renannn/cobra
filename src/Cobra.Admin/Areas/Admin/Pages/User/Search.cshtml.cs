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
    private const int DefaultPageSize = 7;

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

    public async Task OnPostAsync(int? page = 1, string field = "Id", SortOrder order = SortOrder.Ascending)
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
}
