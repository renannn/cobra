using Cobra.Entities.Domains;
using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;

namespace Cobra.Entities.Administration
{
    public class Phone : BaseEntity, IHasId<Guid>, IAuditableEntity, IBaseEntity, IHasName, IHasDisabled, IHasCreationDate, IHasObservation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public short CountryId { get; set; }
        public bool Main { get; set; }
        public virtual Country Country { get; set; }
        public string RegionCode { get; set; }
        public string Number { get; set; }
        public string Extension { get; set; }
        public string Observation { get; set; }
        public bool IsDisabled { get; set; }
        public short PhoneTypeId { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime? CreatedDateTime { get; set; }
    }
}
