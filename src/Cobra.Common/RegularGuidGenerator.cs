using System;

namespace Cobra.Common
{
    /// <summary>
    /// Implements <see cref="T: Cobra.Common.IGuidGenerator" /> by using <see cref="M:System.Guid.NewGuid" />.
    /// </summary>
    public class RegularGuidGenerator : IGuidGenerator
    {
        public RegularGuidGenerator()
        {
        }

        public virtual Guid Create()
        {
            return Guid.NewGuid();
        }
    }
}