using System;
using System.ComponentModel.DataAnnotations;

namespace Cobra.Admin.Areas.Admin.Pages.Parameters.CompanySettings
{
    public class CompanySettingsModel
    {

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "Nome da Empresa")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "Código de Area")]
        public string CodeArea { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }
         
        [Display(Name = "Ramal")]
        public string Ramal { get; set; }

        [Display(Name = "Observação")]
        public string TelefoneObservation { get; set; }
         
        [Required(ErrorMessage = "(*)")]
        [Display(Name = "Tipo de Telefone")]
        public short PhoneTypeId { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "CNPJ")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "Inscrição Estadual")]
        public string IE { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "Nome do Responsavel Legal")]
        public string NomeResponsavel { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "RG do Responsavel Legal")]
        public string RGResponsavel { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "CPF do Responsavel Legal")]
        public string CPFResponsavel { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "Data de Nascimento do Responsavel Legal")]
        public DateTime DataNascimentoResponsavel { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "Código de Area")]
        public string CodeAreaResponsavel { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "Tipo de Telefone")]
        public string TelefoneResponsavel { get; set; }

        [Display(Name = "Ramal")]
        public string RamalResponsavel { get; set; }

        [Display(Name = "Observação")]
        public string TelefoneObservationResponsavel { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "Tipo de Telefone")]
        public short PhoneTypeIdResponsavel { get; set; }


        public string ImageLogo { get; set; }
    }
}
