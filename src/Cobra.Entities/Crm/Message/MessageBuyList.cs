using System;

namespace Cobra.Entities.Crm
{
    public class MessageBuyList : Message
    {
        public Guid BuyListId { get; set; }
        public virtual BuyList BuyList { get; set; }
        public Guid SenderUserId { get; set; }
        public Guid TargetUserId { get; set; }
    }
}
