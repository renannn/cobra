using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cobra.Admin.Areas.Admin.Pages.SubMenu;

public class ItemModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public Guid? Id { get; set; }

    public IActionResult OnGet()
    {
        if (Id.HasValue)
        {

        }

        return Page();
    }
}
