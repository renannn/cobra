using Cobra.Core.Settings;
using Cobra.Entities.Administration;
using Cobra.Infrastructure.Services.Contracts.Identity;
using Cobra.Models.Identity;
using Cobra.Models.Identity.Emails;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Cobra.Admin.Areas.Identity.Pages
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly IEmailSender _emailSender;
        private readonly IApplicationUserManager _userManager;
        private readonly IPasswordValidator<User> _passwordValidator;
        private readonly IOptionsSnapshot<SiteSettings> _siteOptions;

        [BindProperty]
        public ForgotPasswordViewModel PModel { get; set; }

        public ForgotPasswordModel(
            IApplicationUserManager userManager,
            IPasswordValidator<User> passwordValidator,
            IEmailSender emailSender,
            IOptionsSnapshot<SiteSettings> siteOptions)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _passwordValidator = passwordValidator ?? throw new ArgumentNullException(nameof(passwordValidator));
            _emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
            _siteOptions = siteOptions ?? throw new ArgumentNullException(nameof(siteOptions));
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(PModel.Email);
                if (user == null || !await _userManager.IsEmailConfirmedAsync(user))
                {
                    return RedirectToPage("Error");
                }

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                await _emailSender.SendEmailAsync(
                   email: PModel.Email,
                   subject: "Recuperar senha",
                   viewNameOrPath: "~/Areas/Identity/Pages/EmailTemplates/_PasswordReset.cshtml",
                   model: new PasswordResetViewModel
                   {
                       UserId = user.Id,
                       Token = code,
                       EmailSignature = _siteOptions.Value.Smtp.FromName,
                       MessageDateTime = DateTime.Now.ToString("G")
                   });

                return Redirect("/Identity/ForgotPasswordConfirmation");
            }
            return Page();
        }
    }
}