using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cobra.Models.Identity;
using Polly;
using Polly.Retry; 

namespace Cobra.BuyList.Admin.Helpers
{
    public static class RetryPolicyExtensions
    {
        public static Task<T> ExecuteWithTokenAsync<T>(
            this AsyncRetryPolicy retryPolicy,
            TokenResult token,
            Func<Context, Task<T>> action)
        {
            return retryPolicy.ExecuteAsync(action,
                new Dictionary<string, object>
                {
                    { "AccessToken", token.AccessToken },
                    { "RefreshToken", token.RefreshToken }
                });
        }
    }
}