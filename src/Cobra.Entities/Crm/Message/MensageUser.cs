using Cobra.Entities.Administration;
using System;

namespace Cobra.Entities.Crm
{
    public class MensageUser : Message
    {
        public Guid SenderUserId { get; set; }
        public virtual User SenderUser { get; set; }
        public Guid ReceiverUserId { get; set; }
        public virtual User ReceiverUser { get; set; }
    }
}
