using Cobra.Entities.Administration;
using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;

namespace Cobra.Entities.Domains
{
    public class RegionalState : BaseEntity, IHasId<string>, IHasName, IHasCreationDate
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual List<Address> Addresses { get; set; } = new();
        public virtual List<City> Cities { get; set; } = new();
        public DateTime? CreatedDateTime { get; set; }
    }
}
