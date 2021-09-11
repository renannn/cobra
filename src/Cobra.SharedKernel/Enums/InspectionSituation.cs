using System.ComponentModel;

namespace Cobra.SharedKernel.Enums
{
    public enum InspectionSituation : byte
    {
        [Description("Aceito Totalmente")]
        TotalyAccepted,
        [Description("Aceito Parcialmente")]
        PartialAccepted,
        [Description("Negado")]
        Denied
    }
}
