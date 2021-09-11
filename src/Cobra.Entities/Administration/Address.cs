using Cobra.Entities.Domains;
using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;

namespace Cobra.Entities.Administration
{
    public class Address : BaseEntity, IHasId<Guid>, IAuditableEntity, IBaseEntity, IHasName, IHasDisabled, IHasCreationDate, IHasObservation
    {
        public Guid Id { get; set; }
        public string Cep { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public bool Main { get; set; }
        public long CityId { get; set; }
        public virtual City City { get; set; }
        public virtual RegionalState State {  get; set; }
        public string Sigla {  get; set; }
        public string Observation { get; set; }
        public bool IsDisabled { get; set; }
        public short AddressTypeId { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime? CreatedDateTime { get; set; }
    }
}
