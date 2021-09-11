using Cobra.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace Cobra.Infrastructure.Data
{
    public class TransationRepository : ITransationRepository
    {
        private readonly AppDbContext _dbContext;

        public TransationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit(IDbContextTransaction transaction)
        {
            transaction.Commit();
        }

        public IDbContextTransaction CreateTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }

        public void Rollback(IDbContextTransaction transaction)
        {
            transaction.Rollback();
        }
    }
}
