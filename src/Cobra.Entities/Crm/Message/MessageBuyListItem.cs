using System;

namespace Cobra.Entities.Crm
{
    public class MessageBuyListItem : Message
    {
        public Guid BuyListItemId { get; set; }
        public virtual BuyListItem BuyListItem { get; set; }
        public Guid SenderUserId { get; set; }
        public Guid TargetUserId { get; set; }
    }
}
