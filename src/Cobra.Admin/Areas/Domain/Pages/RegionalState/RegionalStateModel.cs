using System.ComponentModel.DataAnnotations;

namespace Cobra.Admin.Areas.Domain.Pages.RegionalStatePage
{
    public class RegionalStateModel
    {
        public string SiglaOld { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "Sigla")]
        public string Sigla { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
    }
}
