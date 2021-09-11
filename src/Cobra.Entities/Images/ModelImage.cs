using Cobra.Entities.Crm;
using System;

namespace Cobra.Entities.Domains
{
    public class ModelImage : Image
    {
        public Guid ModelId { get; set; }
        public virtual Model Model { get; set; }
    }
}
