using System.ComponentModel;

namespace Cobra.SharedKernel.Enums
{
    public enum MessageDirection : byte
    {
        [Description("Enviado")]
        Send = 0,
        [Description("Recebido")]
        Receive = 1
    }
}
