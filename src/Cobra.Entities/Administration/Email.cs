using Cobra.Entities.Domains;
using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;

namespace Cobra.Entities.Administration
{
    public class Email : BaseEntity, IHasId<Guid>, IAuditableEntity, IHasValue<string>, IHasDisabled, IHasCreationDate, IHasObservation
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public string Observation { get; set; }
        public bool Main { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public short EmailTypeId { get; set; }
        public virtual EmailType EmailType { get; set; }
        public bool IsDisabled { get; set; }
        public DateTime? CreatedDateTime { get; set; }
    }
}
