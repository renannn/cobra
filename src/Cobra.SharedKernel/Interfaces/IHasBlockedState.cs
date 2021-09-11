using Cobra.SharedKernel.Enums;

namespace Cobra.SharedKernel.Interfaces
{
    public interface IHasBlockedState
    {
        BlockedState BlockedState { get; set; }
    }
}
