using System.Collections.Generic;

namespace Cobra.SharedKernel.Interfaces
{
    public interface IHasPhones<TPhone> where TPhone : class
    {
        List<TPhone> Phones { get; set; }
    }
}
