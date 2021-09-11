using System.ComponentModel;

namespace Cobra.SharedKernel.Enums
{
    public enum PersonType : short
    {
        [Description("Pessoa Física")]
        PF = 0,
        [Description("Pessoa Jurídica")]
        PJ = 1
    }
}
