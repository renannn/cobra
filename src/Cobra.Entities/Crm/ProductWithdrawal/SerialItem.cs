using Cobra.Entities.Domains;
using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;

namespace Cobra.Entities.Crm;

public class SerialItem : BaseEntity, IHasId<Guid>, IHasValue<string>, IHasDescription, IAuditableEntity, IHasCreationDate
{
    public Guid Id { get; set; }
    public string Value { get; set; }
    public string Description { get; set; }
    public DateTime? CreatedDateTime { get; set; }
    public Guid ProductWithdrawalItemId { get; set; }
    public virtual ProductWithdrawalItem ProductWithdrawalItem { get; set; }
    public virtual List<SerialItemImage> Images { get; set; }
}