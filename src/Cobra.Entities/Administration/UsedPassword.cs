
using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;

namespace Cobra.Entities.Administration
{
    public class UsedPassword : BaseEntity, IHasId<Guid>, IHasCreationDate
    {
        public Guid Id { get; set; }
        public string HashedPassword { get; set; }
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
    }
}
