using System.ComponentModel.DataAnnotations;

namespace Cobra.Admin.Areas.Domain.Pages.EmailTypePage;

public class EmailTypeModel
{
    public short? Id { get; set; }

    [Required(ErrorMessage = "(*)")]
    [Display(Name = "Nome")]
    public string Name { get; set; }

    [Display(Name = "Descrição")]
    public string Description { get; set; }
}

