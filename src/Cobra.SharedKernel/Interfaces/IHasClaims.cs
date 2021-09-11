using System.Collections.Generic;

namespace Cobra.SharedKernel.Interfaces
{
    public interface IHasClaims<TClaims> where TClaims : class
    {
        List<TClaims> Claims { get; set; }
    }
}
