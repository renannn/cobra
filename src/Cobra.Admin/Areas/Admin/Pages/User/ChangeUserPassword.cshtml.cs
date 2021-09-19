using Cobra.Common;
using Cobra.Common.IdentityToolkit;
using Cobra.Core.Settings;
using Cobra.Infrastructure.Services.Contracts.Identity;
using Cobra.Models.Identity;
using Cobra.Models.Identity.Emails;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Cobra.Admin.Areas.Admin.Pages.User
{
    public class ChangeUserPasswordModel : PageModel
    {
        private readonly IEmailSender _emailSender;
        private readonly IApplicationUserManager _userManager;
        private readonly IApplicationSignInManager _signInManager;
        private readonly IPasswordValidator<Entities.Administration.User> _passwordValidator;
        private readonly IUsedPasswordsService _usedPasswordsService;
        private readonly IOptionsSnapshot<SiteSettings> _siteOptions;
        public ChangeUserPasswordModel(
                    IApplicationUserManager userManager,
                    IApplicationSignInManager signInManager,
                    IEmailSender emailSender,
                    IPasswordValidator<Entities.Administration.User> passwordValidator,
                    IUsedPasswordsService usedPasswordsService,
                    IOptionsSnapshot<SiteSettings> siteOptions)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _passwordValidator = passwordValidator ?? throw new ArgumentNullException(nameof(passwordValidator));
            _usedPasswordsService = usedPasswordsService ?? throw new ArgumentNullException(nameof(usedPasswordsService));
            _emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
            _siteOptions = siteOptions ?? throw new ArgumentNullException(nameof(siteOptions));
        }

        [BindProperty(SupportsGet = true)]
        public Guid? Id { get; set; }


        public ChangePasswordViewModel PModel { get; set; }

        public async Task OnGetAsync()
        {
            await Populate();
        }

        private async Task Populate()
        {
            if (Id.HasValue)
            {
                var passwordChangeDate = await _usedPasswordsService.GetLastUserPasswordChangeDateAsync(Id.Value);
                PModel = new ChangePasswordViewModel()
                {
                    LastUserPasswordChangeDate = passwordChangeDate
                };
            }
            else
            {
                var userId = this.User.Identity.GetUserId<string>();
                var passwordChangeDate = await _usedPasswordsService.GetLastUserPasswordChangeDateAsync(new(userId));
                PModel = new ChangePasswordViewModel()
                {
                    LastUserPasswordChangeDate = passwordChangeDate
                };
            }
        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
