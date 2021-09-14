using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cobra.Admin.Areas.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cobra.Admin.Areas.Domain.Pages.PaymentMethodType;

[Area(AreaConstants.IdentityArea)]
[Authorize]
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
