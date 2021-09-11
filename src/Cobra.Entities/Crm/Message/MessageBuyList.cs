using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;

namespace Cobra.Entities.Crm
{
    public class MessageBuyList : BaseEntity, IHasId<long>, IHasValue<string>, IHasCreationDate
    {
        public long Id { get; set; }
        public string Value { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public Guid BuyListId { get; set; }
        public virtual BuyList BuyList { get; set; }
        public Guid SenderUserId { get; set; }
        public Guid TargetUserId { get; set; }
    }
}
