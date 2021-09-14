using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;

namespace Cobra.Entities.Administration
{
    public class CompanySettings : BaseEntity, IAuditableEntity
    {
        public bool CompanyName { get; set; }
        public bool Telefone { get; set; }
        public string CNPJ { get; set; }
        public bool RazaoSocial { get; set; }
        public bool IE { get; set; }
        public string NomeResponsavel { get; set; }
        public string CPFResponsavel { get; set; }
        public DateTime DataNascimentoResponsavel { get; set; }
        public string ImageLogo { get; set; }
    }
}
