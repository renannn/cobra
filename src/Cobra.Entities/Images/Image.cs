using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;

namespace Cobra.Entities.Domains
{
    public abstract class Image : BaseEntity, IHasId<long>, IHasValue<string>, IAuditableEntity, IHasCreationDate
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public DateTime? CreatedDateTime { get; set; }
    }
}
