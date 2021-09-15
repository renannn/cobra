using Cobra.Entities.Domains;
using Cobra.SharedKernel.Interfaces;
using EntityFramework.Exceptions.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Cobra.Admin.Areas.Domain.Pages.EmailTypePage;

[Area(AreaConstants.IdentityArea)]
[Authorize]
public class ItemModel : PageModel
{
    private readonly IRepository<short, EmailType> _repository;
    public ItemModel(IRepository<short, EmailType> repository)
    {
        _repository = repository;
    }

    [BindProperty(SupportsGet = true)]
    public short? Id { get; set; }

    [BindProperty()]
    public EmailTypeModel PModel { get; set; } = new();

    public async Task<IActionResult> OnGetAsync()
    {
        if (Id.HasValue)
        {
            var temp = await _repository.ReadRepository.GetByIdAsync(Id.Value);
            if (temp == null)
            {
                return Page();
            }
            PModel = new EmailTypeModel { Id = temp.Id, Name = temp.Name, Description = temp.Description };
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            try
            {
                EmailType temp;
                bool newItem = false;
                if (PModel.Id.HasValue)
                {
                    temp = await _repository.ReadRepository.GetByIdAsync(PModel.Id.Value);
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
                if (PModel.Id.HasValue)
                {
                    temp.Id = PModel.Id.Value;
                }
                temp.Name = PModel.Name;
                temp.Description = PModel.Description;

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
