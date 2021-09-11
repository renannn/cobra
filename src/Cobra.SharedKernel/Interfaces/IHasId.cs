namespace Cobra.SharedKernel.Interfaces
{
    public interface IHasId<TType>
    {
        TType Id { get; set; }
    }
}
