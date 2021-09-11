using Cobra.Entities.Administration;
using Cobra.Models.Identity;
using System.Threading.Tasks;

namespace Cobra.Infrastructure.Services.Identity
{
    public interface IJWT
    {
        Task<TokenResult> BuildJWTTokenAsync(LoginRequest credenciais);
        Task<User> ValidateJwtTokenAsync(string token);
        Task<bool> ValidateCredentialsAsync(LoginRequest credenciais);
    }
}
