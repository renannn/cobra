using Cobra.Entities.Domains;
using Cobra.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cobra.Admin.Areas.Domain.Pages.BankPage;

public class SearchModel : PageModel
{
    private readonly IRepository<short, Bank> _repository;
    public SearchModel(IRepository<short, Bank> repository)
    {
        _repository = repository;
    }

    [BindProperty()]
    public List<BankModel> List { get; set; } = new();


    [BindProperty()]
    public bool ExibirDesativados { get; set; }

    public async Task OnGetAsync()
    {
        await Populate();
    }

    public async Task OnPostAsync()
    {
        await Populate();
    }

    private async Task Populate()
    {
        List = (await _repository.ReadRepository.QueryAsync(x => true)).Select(x => new BankModel { Id = x.Id, Codigo = x.Codigo, Name = x.Name }).ToList();
    }
}
