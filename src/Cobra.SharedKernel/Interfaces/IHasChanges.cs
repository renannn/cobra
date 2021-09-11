using System.Collections.Generic;

namespace Cobra.SharedKernel.Interfaces
{
    public interface IHasChanges<TChanges> where TChanges : class
    {
        List<TChanges> Changes { get; set; }
    }
}
