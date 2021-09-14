using Cobra.Infrastructure.Services.Contracts.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Cobra.Admin.Areas.Identity.Pages
{
    [Authorize]
    public class LogOffModel : PageModel
    {
        private readonly IApplicationUserManager _userManager;
        private readonly IApplicationSignInManager _signInManager;
        private readonly ILogger<LogOffModel> _logger;

        public LogOffModel(
            IApplicationSignInManager signInManager,
            IApplicationUserManager userManager,
            ILogger<LogOffModel> logger)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = User.Identity.IsAuthenticated ? await _userManager.FindByNameAsync(User.Identity.Name) : null;
            await _signInManager.SignOutAsync();
            if (user != null)
            {
                await _userManager.UpdateSecurityStampAsync(user);
                _logger.LogInformation(4, $"{user.UserName} logged out.");
            }
            return Redirect("/");
        }
    }

}