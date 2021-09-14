using Cobra.SharedKernel;
using Cobra.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;

namespace Cobra.Entities.Crm;

public class ProductWithdrawal : BaseEntity, IHasId<Guid>, IHasName, IHasDescription, IAuditableEntity, IHasCreationDate
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? CreatedDateTime { get; set; }
    public virtual List<ProductWithdrawalItem> Itens { get; set; } = new();
    public Guid BuyListID { get; set; }
    public virtual BuyList BuyList { get; set; }
}