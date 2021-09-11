using Cobra.Entities.Crm;
using System;

namespace Cobra.Entities.Domains
{
    public class BuyListItemImage : Image
    {
        public Guid BuyListItemId { get; set; }
        public virtual BuyListItem BuyListItem { get; set; }
    }
}
