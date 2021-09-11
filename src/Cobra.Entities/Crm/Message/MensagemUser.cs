using Cobra.Entities.Administration;
using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;

namespace Cobra.Entities.Crm
{
    public class MensagemUser : BaseEntity, IHasId<long>, IHasValue<string>, IHasCreationDate
    {
        public long Id { get; set; }
        public string Value { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public Guid SenderUserId { get; set; }
        public virtual User SenderUser { get; set; }
        public Guid TargetUserId { get; set; }
        public virtual User TargetUser { get; set; }
    }
}
