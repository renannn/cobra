using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;

namespace Cobra.Entities.Crm
{
    public class MessageBuyListItem : BaseEntity, IHasId<long>, IHasValue<string>, IHasCreationDate
    {
        public long Id { get; set; }
        public string Value { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public Guid BuyListItemId { get; set; }
        public virtual BuyListItem BuyListItem { get; set; }
        public Guid SenderUserId { get; set; }
        public Guid TargetUserId { get; set; } 
    }
}
