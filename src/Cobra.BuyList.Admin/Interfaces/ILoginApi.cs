using System.Threading.Tasks;
using Cobra.Models.Identity;
using Refit;

namespace Cobra.BuyList.Admin.Interfaces
{
    public interface ILoginApi
    {
        [Post("/v1/auth")]
        Task<TokenResult> Auth(LoginRequest model);
    }
}
