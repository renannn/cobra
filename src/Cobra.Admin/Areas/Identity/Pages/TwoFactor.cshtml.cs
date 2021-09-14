using Cobra.Infrastructure.Services.Contracts.Identity;
using Cobra.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Cobra.Admin.Areas.Identity.Pages
{
    public class TwoFactorModel : PageModel
    {
        private readonly ILogger<TwoFactorModel> _logger;
        private readonly IApplicationSignInManager _signInManager;

        public TwoFactorModel(
            IApplicationSignInManager signInManager,
            ILogger<TwoFactorModel> logger)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public VerifyCodeViewModel PModel { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> GetTaskAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // The following code protects for brute force attacks against the two factor codes.
            // If a user enters incorrect codes for a specified amount of time then the user account
            // will be locked out for a specified amount of time.
            var result = await _signInManager.TwoFactorSignInAsync(
                PModel.Provider,
                PModel.Code,
                false,
                false);

            if (result.Succeeded)
            {
                if (Url.IsLocalUrl(PModel.ReturnUrl))
                {
                    return Redirect(PModel.ReturnUrl);
                }
                return Redirect("/");
            }

            if (result.IsLockedOut)
            {
                _logger.LogWarning(7, "User account locked out.");
                return Redirect("Lockout");
            }

            ModelState.AddModelError(string.Empty, "O código inserido é inválido.");
            return Page();
        }
    }
}