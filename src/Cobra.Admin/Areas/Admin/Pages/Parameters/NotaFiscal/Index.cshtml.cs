using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cobra.Admin.Areas.Admin.Pages.Parameters.NotaFiscal;

[Area(AreaConstants.IdentityArea)]
[Authorize]
public class IndexModel : PageModel
{
    public void OnGet()
    {
    }
}
