using Cobra.Core.Settings;
using Cobra.Infrastructure.Services.Contracts.Identity;
using Cobra.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Cobra.Admin.Areas.Identity.Pages
{
    [Area(AreaConstants.IdentityArea)]
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;
        private readonly IApplicationSignInManager _signInManager;
        private readonly IApplicationUserManager _userManager;
        private readonly IOptionsSnapshot<SiteSettings> _siteOptions;

        public LoginModel(
            IApplicationSignInManager signInManager,
            IApplicationUserManager userManager,
            IOptionsSnapshot<SiteSettings> siteOptions,
            ILogger<LoginModel> logger)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _siteOptions = siteOptions ?? throw new ArgumentNullException(nameof(siteOptions));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [BindProperty()]
        public LoginViewModel PModel { get; set; }

        public void OnGet(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(PModel.Username);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "O nome de usuário ou senha inseridos não é válido.");
                    return Page();
                }

                if (user.IsDisabled || user.BlockedState == SharedKernel.Enums.BlockedState.IsBlocked)
                {
                    ModelState.AddModelError(string.Empty, "Sua conta foi desativada.");
                    return Page();
                }

                if (_siteOptions.Value.EnableEmailConfirmation &&
                  !await _userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError("", "Por favor, vá para o seu e-mail e confirme seu e-mail!");
                    return Page();
                }
                var result = await _signInManager.PasswordSignInAsync(
                                      PModel.Username,
                                      PModel.Password,
                                      false,
                                      lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    _logger.LogInformation(1, $"{PModel.Username} logged in.");
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return Redirect("/");
                }

                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("TwoFactor", new { action = "TwoFactor" });
                }

                if (result.IsLockedOut)
                {
                    _logger.LogWarning(2, $"{PModel.Username} está bloqueado.");
                    return Page();
                }

                if (result.IsNotAllowed)
                {
                    ModelState.AddModelError(string.Empty, "Login indisponível.");
                    return Page();
                }

                ModelState.AddModelError(string.Empty, "O nome de usuário ou senha inseridos não é válido.");
            }
            return Page();
        }
    }
}