using System.Collections.Generic;

namespace Cobra.SharedKernel.Interfaces
{
    public interface IHasAddresses<TAddress> where TAddress : class
    {
        List<TAddress> Addresses { get; set; }
    }
}
