using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;

namespace Cobra.Entities.Administration
{
    public class CompanySettings : BaseEntity, IAuditableEntity
    {
        public string CompanyName { get; set; }
        public string CodeArea { get; set; }
        public string Telefone { get; set; }
        public string Ramal { get; set; }
        public string TelefoneObservation { get; set; }
        public short PhoneTypeId { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string IE { get; set; }
        public string NomeResponsavel { get; set; }
        public string CPFResponsavel { get; set; }
        public DateTime DataNascimentoResponsavel { get; set; }
        public string TelefoneResponsavel { get; set; }
        public string RamalResponsavel { get; set; }
        public string TelefoneObservationResponsavel { get; set; }
        public short PhoneTypeIdResponsavel { get; set; }
        public string ImageLogo { get; set; }
    }
}
