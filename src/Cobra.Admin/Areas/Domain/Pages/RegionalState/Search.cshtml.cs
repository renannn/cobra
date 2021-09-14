using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cobra.Entities.Domains;
using Cobra.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cobra.Admin.Areas.Domain.Pages.RegionalStatePage;

public class SearchModel : PageModel
{
    private readonly IRepository<string, RegionalState> _repository;
    public SearchModel(IRepository<string, RegionalState> repository)
    {
        _repository = repository;
    }

    [BindProperty()]
    public List<RegionalStateModel> List { get; set; } = new();


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
        List = (await _repository.ReadRepository.QueryAsync(x => true)).Select(x => new RegionalStateModel { Sigla = x.Id, Nome = x.Name }).ToList();
    }
}
