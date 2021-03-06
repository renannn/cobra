using Cobra.Entities.Administration;
using System;

namespace Cobra.Entities.Crm
{
    public class MessageBuyList : Message
    {
        public Guid BuyListId { get; set; }
        public virtual BuyList BuyList { get; set; }
        public Guid SenderUserId { get; set; }
        public virtual User SenderUser { get; set; }
        public Guid ReceiverUserId { get; set; }
        public virtual User ReceiverUser { get; set; }
    }
}
