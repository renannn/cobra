using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;

namespace Cobra.Entities.Crm;

public class ProductWithdrawalItem : BaseEntity, IHasId<Guid>, IHasDescription, IAuditableEntity, IHasCreationDate
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public DateTime? CreatedDateTime { get; set; }
    public Guid BuyListItemId { get; set; }
    public virtual BuyListItem BuyListItem { get; set; }
    public virtual List<SerialItem> Serials { get; set; } = new();
    public Guid ProductWithdrawalId { get; set; }
    public virtual ProductWithdrawal ProductWithdrawal {  get; set; }
}