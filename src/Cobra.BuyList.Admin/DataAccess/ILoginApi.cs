using System.Threading.Tasks;
using Cobra.Models.Identity;
using Refit;

namespace Cobra.BuyList.Admin.DataAccess
{
    public interface ILoginApi
    {
        [Post("/v1/auth")]
        Task<TokenResult> AuthAsync(LoginRequest model);
    }
}
