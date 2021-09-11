using Cobra.Entities.Crm;

namespace Cobra.Entities.Domains
{
    public class InspectionItemImage : Image
    {
        public virtual InspectionItem InspectionItem { get; set; }
        public int InspectionItemId { get; set; }
    }
}
