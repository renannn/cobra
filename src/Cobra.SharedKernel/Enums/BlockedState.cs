using System.ComponentModel;

namespace Cobra.SharedKernel.Enums
{
    public enum BlockedState : byte
    {
        [Description("Bloqueado")]
        IsBlocked = 0,
        [Description("Desbloqueado")]
        UnBloqued = 1
    }
}
