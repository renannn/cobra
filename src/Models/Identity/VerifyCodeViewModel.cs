using System.ComponentModel.DataAnnotations;

namespace Cobra.Models.Identity
{
    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Display(Name = "Código de segurança")]
        [Required(ErrorMessage = "(*)")]
        public string Code { get; set; }

        public string ReturnUrl { get; set; }

        [Display(Name = "Lembrando do navegador atual?")]
        public bool RememberBrowser { get; set; }

        [Display(Name = "Lembre-se de mim")]
        public bool RememberMe { get; set; }
    }
}