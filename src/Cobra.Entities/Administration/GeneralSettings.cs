using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;

namespace Cobra.Entities.Administration
{
    public class GeneralSettings : BaseEntity, IAuditableEntity
    {
        public string TermsOfUse { get; set; }
    }
}
