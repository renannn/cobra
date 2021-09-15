using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;

namespace Cobra.Entities.Administration
{
    public class Notification : BaseEntity, IAuditableEntity
    {
        public bool IsEnabled { get; set; }
        public string MerchantName { get; set; }
        public string MerchantId { get; set; }
    }
}
