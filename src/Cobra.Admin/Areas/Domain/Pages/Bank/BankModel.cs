using System.ComponentModel.DataAnnotations;

namespace Cobra.Admin.Areas.Domain.Pages.BankPage
{
    public class BankModel
    {
        public short? Id { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "Código")]
        public short Codigo { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "Nome")]
        public string Name { get; set; }
    }
}
