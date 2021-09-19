using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace Cobra.Admin.Areas.Admin.Pages.User;

[Area(AreaConstants.IdentityArea)]
[Authorize(Roles = "Admin")]
public class ItemModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public Guid? Id { get; set; }

    public IActionResult OnGetCadastro()
    {
        return Page();
    }

    public IActionResult OnGetEditar()
    {
        if (Id.HasValue)
        {

        }

        return Page();
    }
}
