using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cobra.Entities.Domains;
using Cobra.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cobra.Admin.Areas.Domain.Pages.EmailTypePage;

public class SearchModel : PageModel
{
    private readonly IRepository<short, EmailType> _repository;
    public SearchModel(IRepository<short, EmailType> repository)
    {
        _repository = repository;
    }

    [BindProperty()]
    public List<EmailTypeModel> List { get; set; } = new();


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
        List = (await _repository.ReadRepository.QueryAsync(x => true)).Select(x => new EmailTypeModel { Id = x.Id, Name = x.Name, Description = x.Description }).ToList();
    }
}
