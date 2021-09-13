using Cobra.BuyList.Admin.Interfaces;
using Polly;
using Polly.Retry;
using Refit;
using System;
using System.Net;

namespace Cobra.BuyList.Admin.Services
{
    public class BaseHttpClientService
    {
        private readonly IAuthenticationService _authenticationService;

        public BaseHttpClientService(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService; 
        }

        private AsyncRetryPolicy CreateAccessTokenPolicyAsync()
        {
            return Policy
                .HandleInner<ApiException>(
                    ex => ex.StatusCode == HttpStatusCode.Unauthorized)
                .RetryAsync(1, async (ex, retryCount, context) =>
                {


                    await _authenticationService.AuthWithRefreshTokenAsync(
                        context["RefreshToken"].ToString());
                    if (_token != null && !_token.Authenticated)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
        
                        await AutenticarComSenhaAsync();
                    }
                    else
                        await Console.Out.WriteLineAsync("Refresh Token válido...");

                    Console.ForegroundColor = corAnterior;

                    if (!(_token?.Authenticated ?? false))
                        throw new InvalidOperationException("Token inválido!");

                    context["AccessToken"] = _token.AccessToken;
                    context["RefreshToken"] = _token.RefreshToken;
                });
        }

    }
}
