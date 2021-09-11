using Cobra.Entities.Domains;
using Cobra.SharedKernel;
using Cobra.SharedKernel.Enums;
using Cobra.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;

namespace Cobra.Entities.Crm
{
    public class InspectionItem : BaseEntity, IHasId<int>, IHasCreationDate, IHasObservation
    {
        public int Id { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string Observation { get; set; }
        public string SerialName { get; set; }
        public virtual Inspection Inspection { get; set; }
        public virtual List<InspectionItemImage> Images { get; set; }
        public Guid BuyListItemId { get; set; }
        public int InspectionId { get; set; }
        public virtual InspectionSituation Situation { get; set; }
    }
}