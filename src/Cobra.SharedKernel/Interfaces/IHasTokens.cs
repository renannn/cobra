using System.Collections.Generic;

namespace Cobra.SharedKernel.Interfaces
{
    public interface IHasTokens<TUserToken>
    {
        List<TUserToken> Tokens { get; set; }
    }
}
