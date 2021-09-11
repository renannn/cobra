namespace Cobra.SharedKernel.Interfaces
{
    public interface IRepository<TId, T>
        where T : class, IBaseEntity, IHasId<TId>
    {
        IReadRepository<TId, T> ReadRepository { get; }
        IWriteRepository<TId, T> WriteRepository { get; }
        ITransationRepository TransationRepository { get; }
    }
}
