
using Cobra.Entities.Administration;
using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;

namespace Cobra.Entities.Crm
{
    public class Payment : BaseEntity, IHasId<Guid>, IHasDescription, IAuditableEntity, IHasCreationDate
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
        //public virtual PaymentMethod PaymentMethod { get; set; }
        public Guid PaymentMethodId { get; set; }
        //public virtual BuyList BuyList { get; set; }
        public Guid BuyListId { get; set; }
    }
}
