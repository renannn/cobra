using Microsoft.EntityFrameworkCore.Storage;

namespace Cobra.SharedKernel.Interfaces
{
    public interface ITransationRepository
    {
        IDbContextTransaction CreateTransaction();
        void Commit(IDbContextTransaction transaction);
        void Rollback(IDbContextTransaction transaction);
    }
}
