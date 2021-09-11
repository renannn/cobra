using Cobra.Entities.Administration;
using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;

namespace Cobra.Entities.Domains
{
    public class City : BaseEntity, IHasId<long>, IHasName, IHasDescription, IAuditableEntity, IHasCreationDate
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PhoneCode { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public virtual List<Address> Addresses { get; set; }
        public virtual RegionalState State { get; set; }
        public string Sigla { get; set; }
    }
}