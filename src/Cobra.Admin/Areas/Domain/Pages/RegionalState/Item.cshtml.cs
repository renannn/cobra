using System;
using System.Threading.Tasks;
using Cobra.Entities.Domains;
using Cobra.SharedKernel.Interfaces;
using EntityFramework.Exceptions.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cobra.Admin.Areas.Domain.Pages.RegionalStatePage;

[Area(AreaConstants.IdentityArea)]
[Authorize]
public class ItemModel : PageModel
{
    private readonly IRepository<string, RegionalState> _repository;
    public ItemModel(IRepository<string, RegionalState> repository)
    {
        _repository = repository;
    }

    [BindProperty(SupportsGet = true)]
    public String Id { get; set; }

    [BindProperty()]
    public RegionalStateModel PModel { get; set; } = new();

    public async Task<IActionResult> OnGetAsync()
    {
        if (!string.IsNullOrEmpty(Id))
        {
            var temp = await _repository.ReadRepository.GetByIdAsync(Id);
            if (temp == null)
            {
                Id = string.Empty;
                return Page();
            }
            PModel = new RegionalStateModel { Sigla = temp.Id, Nome = temp.Name, SiglaOld = temp.Id };
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            try
            {
                RegionalState temp;
                bool newItem = false;
                if (!string.IsNullOrEmpty(PModel.SiglaOld))
                {
                    temp = await _repository.ReadRepository.GetByIdAsync(PModel.SiglaOld);
                    if (temp == null)
                    {
                        temp = new();
                        newItem = true;
                    }
                }
                else
                {
                    temp = new();
                    newItem = true;
                }

                temp.Id = PModel.Sigla.ToUpperInvariant();
                temp.Name = PModel.Nome;

                if (newItem)
                {
                    temp = await _repository.WriteRepository.AddAsync(temp);
                }
                else
                {
                    temp = await _repository.WriteRepository.UpdateAsync(temp);
                }

                return Redirect($"Item/{temp.Id}");
            }
            catch (UniqueConstraintException u)
            {
                ModelState.AddModelError(string.Empty, "Item com duplicidade de informações.");
                return Page();
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Ocorreu um erro durante o cadastro.");
            }
        }
        return Page();
    }
}
