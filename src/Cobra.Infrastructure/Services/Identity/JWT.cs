using Cobra.Core.Settings;
using Cobra.Entities.Administration;
using Cobra.Infrastructure.Services.Contracts.Identity;
using Cobra.Models.Identity;
using Cobra.SharedKernel.Enums;
using Cobra.SharedKernel.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Cobra.Infrastructure.Services.Identity
{
    public class JWT : IJWT
    {
        private readonly ILogger<JWT> _logger;
        private readonly IApplicationUserManager _userManager;
        private readonly IApplicationSignInManager _signInManager;
        private readonly IReadRepository<Guid, User> _UserReadRepository;
        private readonly IOptionsSnapshot<SiteSettings> _siteOptions;
        private readonly IDistributedCache _cache;


        public JWT(IOptionsSnapshot<SiteSettings> siteOptions,
            IApplicationSignInManager signInManager,
            IApplicationUserManager userManager,
            IReadRepository<Guid, User> UserReadRepository,
            ILogger<JWT> logger,
            IDistributedCache cache)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _siteOptions = siteOptions ?? throw new ArgumentNullException(nameof(siteOptions));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _UserReadRepository = UserReadRepository ?? throw new ArgumentNullException(nameof(UserReadRepository));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public async Task<bool> ValidateCredentialsAsync(LoginRequest credenciais)
        {
            bool credenciaisValidas = false;
            if (credenciais != null && !String.IsNullOrWhiteSpace(credenciais.Username))
            {
                if (credenciais.GrantType == "password")
                {
                    var userIdentity = await _userManager.FindByNameAsync(credenciais.Username);
                    if (userIdentity != null)
                    {
                        // Efetua o login com base no Id do usuário e sua senha
                        var resultadoLogin = await _signInManager.CheckPasswordSignInAsync(userIdentity, credenciais.Password, false);
                        if (resultadoLogin.Succeeded)
                        {
                            await AuthenticateAsync(userIdentity);
                        }
                        credenciaisValidas = true;
                    }
                }
            }
            else if (credenciais.GrantType == "refresh_token")
            {
                if (!String.IsNullOrWhiteSpace(credenciais.RefreshToken))
                {
                    RefreshTokenData refreshTokenBase = null;
                    string strTokenArmazenado = _cache.GetString(credenciais.RefreshToken);
                    if (!String.IsNullOrWhiteSpace(strTokenArmazenado))
                    {
                        refreshTokenBase = JsonConvert.DeserializeObject<RefreshTokenData>(strTokenArmazenado);

                        credenciaisValidas = (refreshTokenBase != null &&
                            credenciais.Username == refreshTokenBase.Username &&
                            credenciais.RefreshToken == refreshTokenBase.RefreshToken);

                        // Elimina o token de refresh já que um novo será gerado
                        if (credenciaisValidas)
                            _cache.Remove(credenciais.RefreshToken);
                    }
                }
            }
            return credenciaisValidas;
        }

        public async Task<TokenResult> BuildJWTTokenAsync(LoginRequest credenciais)
        {
            var userIdentity = await _userManager.FindByNameAsync(credenciais.Username);

            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(credenciais.Username, "Login"),
                new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, userIdentity.UserName),
                        new Claim("id", userIdentity.Id.ToString())
                }
            );

            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao + TimeSpan.FromMinutes(_siteOptions.Value.Security.Tokens.MinutesExpiration);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_siteOptions.Value.Security.Tokens.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var issuer = _siteOptions.Value.Security.Tokens.Issuer;
            var audience = _siteOptions.Value.Security.Tokens.Audience;

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = issuer,
                Audience = audience,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao,
                SigningCredentials = creds
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            var token = tokenHandler.WriteToken(securityToken);

            var resultado = new TokenResult()
            {
                Authenticated = true,
                Created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                Expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                AccessToken = token,
                RefreshToken = Guid.NewGuid().ToString().Replace("-", String.Empty),
                Message = "OK"
            };

            // Armazena o refresh token em cache através do Redis 
            var refreshTokenData = new RefreshTokenData
            {
                RefreshToken = resultado.RefreshToken,
                Username = credenciais.Username
            };

            // Calcula o tempo máximo de validade do refresh token
            // (o mesmo será invalidado automaticamente pelo Redis)
            TimeSpan finalExpiration =
                TimeSpan.FromMinutes(_siteOptions.Value.Security.Tokens.FinalExpiration);

            DistributedCacheEntryOptions opcoesCache =
               new DistributedCacheEntryOptions();
            opcoesCache.SetAbsoluteExpiration(finalExpiration);
            _cache.SetString(resultado.RefreshToken,
                JsonConvert.SerializeObject(refreshTokenData),
                opcoesCache);

            _ = await _userManager.SetAuthenticationTokenAsync(userIdentity, "JWT", "JWT Token", token);

            return resultado;
        }

        private async Task<User> AuthenticateAsync(User user)
        {
            if (user == null)
            {
                throw new Exception("O nome de usuário ou senha inseridos não é válido.");
            }

            if (user.BlockedState == BlockedState.IsBlocked)
            {
                throw new Exception("Sua conta foi bloqueada.");
            }

            if (user.IsDisabled)
            {
                throw new Exception("Sua conta foi desativada.");
            }

            if (_siteOptions.Value.EnableEmailConfirmation &&
                !await _userManager.IsEmailConfirmedAsync(user))
            {
                throw new Exception("Por favor, confirme seu e-mail!");
            }
            return user;
        }

        public async Task<User> ValidateJwtTokenAsync(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_siteOptions.Value.Security.Tokens.Key);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var accountId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                return await _UserReadRepository.GetByIdAsync(accountId);
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }


    }
}
