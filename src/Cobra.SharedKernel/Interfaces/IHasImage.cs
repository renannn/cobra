using System.Collections.Generic;

namespace Cobra.SharedKernel.Interfaces
{
    public interface IHasImage<TImage> where TImage : class
    {
        List<TImage> Images { get; set; }
    }
}
