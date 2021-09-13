using System;

namespace Cobra.Entities.Crm
{
    public class MensagemUser : Message
    {
        public Guid SenderUserId { get; set; }
        public Guid TargetUserId { get; set; }
    }
}
