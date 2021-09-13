using Cobra.BuyList.Admin.DataAccess;
using Cobra.BuyList.Admin.Interfaces;
using Cobra.Models.Identity;
using System;
using System.Threading.Tasks;

namespace Cobra.BuyList.Admin.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private TokenResult _token;
        private readonly ILocalStorageService _localStorageService;
        private readonly ILoginApi _loginApi;


        private string _userKey = "user";

        public AuthenticationService(ILocalStorageService localStorageService, ILoginApi loginApi)
        {
            _localStorageService = localStorageService ?? throw new ArgumentNullException(nameof(localStorageService));
            _loginApi = loginApi ?? throw new ArgumentNullException(nameof(loginApi));
        }

        public bool IsAuthenticatedUsingToken
        {
            get => _token?.Authenticated ?? false;
        }

        public TokenResult Token => _token;

        public async Task AuthWithPasswordAsync(LoginRequest loginRequest)
        {
            try
            {
                // Envio da requisição a fim de autenticar
                // e obter o token de acesso
                _token = await _loginApi.AuthAsync(
                new LoginRequest
                {
                    Username = loginRequest.Username,
                    Password = loginRequest.Password,
                    GrantType = "password"
                });
                await _localStorageService.SetItem(_userKey, _token);
            }
            catch
            {
                _token = null;
                throw;
            }
        }

        public async Task AuthWithRefreshTokenAsync(string refreshToken)
        {
            try
            {
                // Envio da requisição com Refresh Token
                // a fim de obter um novo token de acesso
                _token = await _loginApi.AuthAsync(
                  new LoginRequest
                  {
                      Username = _token.Nome,
                      RefreshToken = refreshToken,
                      GrantType = "refresh_token"
                  });
                await _localStorageService.SetItem(_userKey, _token);
            }
            catch (Exception)
            {
                _token = null;
                throw;
            }
        }

        public async Task Initialize()
        {
            await Task.Run(async () =>
            {
                _token = await _localStorageService.GetItem<TokenResult>(_userKey);
            });
        }

        public async Task Logoff()
        {
            await Task.Run(() =>
            {
                _token = null;
            });
        }
    }
}
