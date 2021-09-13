using System.ComponentModel;

namespace Cobra.SharedKernel.Enums
{
    public enum BlockedState : byte
    {
        [Description("Bloqueado")]
        IsBlocked = 1,
        [Description("Desbloqueado")]
        UnBloqued = 0
    }
}
