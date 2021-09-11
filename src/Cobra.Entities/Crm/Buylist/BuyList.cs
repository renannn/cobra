using Cobra.Entities.Administration;
using Cobra.SharedKernel;
using Cobra.SharedKernel.Enums;
using Cobra.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;

namespace Cobra.Entities.Crm
{
    public class BuyList : BaseEntity, IHasId<Guid>, IHasName, IHasDescription, IAuditableEntity, IHasCreationDate, IHasSituation<BuyListSituation>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public BuyListSituation Situation { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public Guid ReceptionAddressId { get; set; }
        public string ReceptionAddressObservation { get; set; }
        public virtual List<BuyListItem> BuyListItens { get; set; } = new();
        public virtual List<Inspection> Inspections { get; set; } = new();
        public virtual List<MessageBuyList> Messages { get; set; } = new();
    }
}
