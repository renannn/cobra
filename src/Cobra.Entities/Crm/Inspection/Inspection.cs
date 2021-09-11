using Cobra.SharedKernel;
using Cobra.SharedKernel.Enums;
using Cobra.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;

namespace Cobra.Entities.Crm
{
    public class Inspection : BaseEntity, IHasId<int>, IHasCreationDate, IHasObservation, IHasSituation<InspectionSituation>
    {
        public int Id { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime ScheduledDateTime { get; set; }
        public InspectionSituation Situation { get; set; }
        public virtual BuyList BuyList { get; set; }
        public Guid BuyListId { get; set; }
        public string Observation { get; set; }
        public virtual List<InspectionItem> InspectionItens { get; set; } = new();
    }
}