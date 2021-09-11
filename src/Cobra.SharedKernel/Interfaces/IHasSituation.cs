namespace Cobra.SharedKernel.Interfaces
{
    public interface IHasSituation<TEnum>
    {
        TEnum Situation { get; set; }
    }
}
