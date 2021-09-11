using System.ComponentModel;

namespace Cobra.SharedKernel.Enums
{
    public enum AuditAction : byte
    {
        [Description("Criação")]
        Creation = 0,
        [Description("Modificação")]
        Updated = 1
    }
}
