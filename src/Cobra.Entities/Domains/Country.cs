using Cobra.Entities.Administration;
using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;

namespace Cobra.Entities.Domains
{
    public class Country : BaseEntity, IHasId<short>, IHasName, IHasDescription, IAuditableEntity, IHasCreationDate
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public short CountryCode { get; set; }
        public string InternationalPrefix { get; set; }
        public string NationalPrefix { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public virtual List<Phone> Phones { get; set; } = new();
        public string Flag { get; set; }
    }
}
