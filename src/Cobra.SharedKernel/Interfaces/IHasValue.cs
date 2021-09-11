namespace Cobra.SharedKernel.Interfaces
{
    public interface IHasValue<TType>
    {
        TType Value { get; set; }
    }
}