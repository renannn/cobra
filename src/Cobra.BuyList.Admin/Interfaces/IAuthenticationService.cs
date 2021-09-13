using Cobra.Models.Identity;
using System.Threading.Tasks;

namespace Cobra.BuyList.Admin.Interfaces
{
    public interface IAuthenticationService
    {
        TokenResult Token { get; }
        bool IsAuthenticatedUsingToken { get; }
        Task Initialize(); 
        Task AuthWithPasswordAsync(LoginRequest loginRequest);
        Task AuthWithRefreshTokenAsync(string refreshToken);
        Task Logoff();
    }
}
