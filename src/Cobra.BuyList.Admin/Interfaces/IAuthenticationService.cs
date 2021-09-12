using Cobra.Models.Identity;
using System.Threading.Tasks;

namespace Cobra.BuyList.Admin.Interfaces
{
    public interface IAuthenticationService
    {
        bool IsAuthenticatedUsingToken { get; }
        Task Initialize(); 
        Task AuthWithPasswordAsync(LoginRequest loginRequest);
        Task AuthWithRefreshTokenAsync();
    }
}
