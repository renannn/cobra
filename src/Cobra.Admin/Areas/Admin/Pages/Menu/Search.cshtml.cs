using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cobra.Admin.Areas.Admin.Pages.Menu;

[Area(AreaConstants.IdentityArea)]
[Authorize]
public class SearchModel : PageModel
{
    public void OnGet()
    {
    }
}
