using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;

namespace Cobra.Entities.Administration
{
    public class Testimony : BaseEntity, IHasId<long>, IAuditableEntity, IBaseEntity, IHasDisabled, IHasCreationDate, IHasObservation
    {
        public long Id { get; set; }
        public bool IsDisabled { get; set; }
        public Decimal Ratting { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string Observation { get; set; }
        public Guid ReceiverUserId { get; set; } 
        public Guid SenderUserId { get; set; }
    }
}
