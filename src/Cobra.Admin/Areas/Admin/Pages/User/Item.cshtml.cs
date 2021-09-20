using Cobra.Common;
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
public class ItemModel : PageModel
{
    private readonly IApplicationUserManager _userManager;
    private readonly IProtectionProviderService _protectionProviderService;
    private readonly IUsedPasswordsService _usedPasswordsService;

    public ItemModel(IApplicationUserManager userManage, IProtectionProviderService protectionProviderService, IUsedPasswordsService usedPasswordsService)
    {
        _userManager = userManage ?? throw new ArgumentNullException(nameof(userManage));
        _protectionProviderService = protectionProviderService ?? throw new ArgumentNullException(nameof(protectionProviderService));
        _usedPasswordsService = usedPasswordsService ?? throw new ArgumentNullException(nameof(usedPasswordsService));
    }

    [BindProperty(SupportsGet = true)]
    public Guid? Id { get; set; }

    [BindProperty]
    public UserProfileViewModel PModel { get; set; }

    public IActionResult OnGet()
    {
        PModel = new UserProfileViewModel();
        return Page();
    }

    public async Task<IActionResult> OnGetEditarAsync()
    {
        if (Id.HasValue)
        {
            var user = await _userManager.FindByIdAsync(Id.Value.ToString());
            var userProfile = new UserProfileViewModel
            {
                IsAdminEdit = true,
                Email = user.Email,
                PhotoFileName = user.PhotoFileName,
                UserName = user.UserName,
                FirstName = user.Name,
                LastName = user.Surname,
                Pid = _protectionProviderService.Encrypt(user.Id.ToString()),
                IsEmailPublic = user.IsEmailPublic,
                TwoFactorEnabled = user.TwoFactorEnabled,
                IsPasswordTooOld = await _usedPasswordsService.IsLastUserPasswordTooOldAsync(user.Id)
            };

            PModel = userProfile;
        }

        return Page();
    }
}
