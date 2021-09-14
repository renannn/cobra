using Cobra.Entities.Domains;
using Cobra.SharedKernel;
using Cobra.SharedKernel.Enums;
using Cobra.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;

namespace Cobra.Entities.Crm
{
    public class BuyListItem : BaseEntity, IHasId<Guid>, IHasDescription, IAuditableEntity, IHasCreationDate, IHasSituation<BuyListSituation>
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid ModelId { get; set; }
        public virtual Model Model { get; set; }
        public int ConditionId { get; set; }
        public virtual Condition Condition { get; set; }
        public Guid BuyListId { get; set; }
        public virtual BuyList BuyList { get; set; }
        public Decimal Price { get; set; }
        public int Quantity { get; set; }
        public BuyListSituation Situation { get; set; }
        public virtual List<BuyListItemImage> Images { get; set; } = new();
        public virtual List<MessageBuyListItem> Messages { get; set; } = new();
        public virtual List<ProductWithdrawalItem> ProductWithdrawalItens { get; set; } = new();
        public DateTime? CreatedDateTime { get; set; }
    }
}