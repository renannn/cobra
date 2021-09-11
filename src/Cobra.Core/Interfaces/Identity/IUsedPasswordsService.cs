using Cobra.Entities.Administration;
using System;
using System.Threading.Tasks;

namespace Cobra.Infrastructure.Services.Contracts.Identity
{
    public interface IUsedPasswordsService
    {
        Task<bool> IsPreviouslyUsedPasswordAsync(User user, string newPassword);
        Task AddToUsedPasswordsListAsync(User user);
        Task<bool> IsLastUserPasswordTooOldAsync(Guid userId);
        Task<DateTime?> GetLastUserPasswordChangeDateAsync(Guid userId);
    }
}