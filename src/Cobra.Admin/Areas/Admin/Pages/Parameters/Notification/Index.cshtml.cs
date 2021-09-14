using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Cobra.Admin.Areas.Admin.Pages.Parameters.Notification;

[Area(AreaConstants.IdentityArea)]
[Authorize]
public class IndexModel : PageModel
{
    [BindProperty()]
    public NotificationsModel PModel { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            await Task.Run(() =>
            {

            });
        }
        return Page();
    }
}

