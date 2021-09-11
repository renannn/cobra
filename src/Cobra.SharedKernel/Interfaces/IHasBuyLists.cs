using System.Collections.Generic;

namespace Cobra.SharedKernel.Interfaces
{
    public interface IHasBuyLists<TBuyList> where TBuyList : class
    {
        List<TBuyList> BuyLists { get; set; }
    }
}
