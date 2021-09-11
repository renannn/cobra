using System.Collections.Generic;

namespace Cobra.SharedKernel.Interfaces
{
    public interface IHasTestimonies<TTestimony> where TTestimony : class
    {
        List<TTestimony> Testimonies { get; set; }
    }
}
