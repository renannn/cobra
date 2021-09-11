using Cobra.SharedKernel.Interfaces;

namespace Cobra.Infrastructure.Data
{
    public class Repository<TId, T> : IRepository<TId, T>
        where T : class, IBaseEntity, IHasId<TId>
    {
        private readonly IReadRepository<TId, T> _readRepository;
        private readonly IWriteRepository<TId, T> _writeRepository;
        private readonly ITransationRepository _transationRepository;

        public Repository(IReadRepository<TId, T> readRepository, IWriteRepository<TId, T> writeRepository, ITransationRepository transationRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _transationRepository = transationRepository;
        }

        public IReadRepository<TId, T> ReadRepository => _readRepository;

        public IWriteRepository<TId, T> WriteRepository => _writeRepository;

        public ITransationRepository TransationRepository => _transationRepository;
    }
}
