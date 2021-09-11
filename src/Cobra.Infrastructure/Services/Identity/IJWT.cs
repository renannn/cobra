using Cobra.Entities.Administration;
using System.Threading.Tasks;

namespace Cobra.Infrastructure.Services.Identity
{
    public interface IJWT
    {
        Task<string> BuildJWTTokenAsync(User usuario);
        Task<User> ValidateJwtTokenAsync(string token);
    }
}
