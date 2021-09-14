using Cobra.Entities.Crm;
using System;

namespace Cobra.Entities.Domains
{
    public class SerialItemImage : Image
    {
        public Guid SerialItemId { get; set; }
        public virtual SerialItem SerialItem { get; set; }
    }
}
