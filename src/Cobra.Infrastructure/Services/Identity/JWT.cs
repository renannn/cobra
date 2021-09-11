using Cobra.Core.Settings;
using Cobra.Entities.Administration;
using Cobra.Infrastructure.Services.Contracts.Identity;
using Cobra.SharedKernel.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cobra.Infrastructure.Services.Identity
{
    public class JWT : IJWT
    {
        private readonly ILogger<JWT> _logger;
        private readonly IApplicationSignInManager _signInManager;
        private readonly IApplicationUserManager _userManager;
        private readonly IReadRepository<Guid, User> _UserReadRepository;
        private readonly IOptionsSnapshot<SiteSettings> _siteOptions;


        public JWT(IOptionsSnapshot<SiteSettings> siteOptions,
            IApplicationSignInManager signInManager,
            IApplicationUserManager userManager,
            IReadRepository<Guid, User> UserReadRepository,
            ILogger<JWT> logger)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _siteOptions = siteOptions ?? throw new ArgumentNullException(nameof(siteOptions));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _UserReadRepository = UserReadRepository ?? throw new ArgumentNullException(nameof(UserReadRepository));
        }

        public async Task<string> BuildJWTTokenAsync(User usuario)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_siteOptions.Value.Security.Tokens.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var issuer = _siteOptions.Value.Security.Tokens.Issuer;
            var audience = _siteOptions.Value.Security.Tokens.Audience;

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = issuer,
                Audience = audience,
                Subject = new ClaimsIdentity(new[] { new Claim("id", usuario.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var tk = tokenHandler.WriteToken(token);
            _ = await _userManager.SetAuthenticationTokenAsync(usuario, "JWT", "JWT Token", tk);

            return tk;
        }

        public async Task<User> ValidateJwtTokenAsync(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("[SECRET USED TO SIGN AND VERIFY JWT TOKENS, IT CAN BE ANY STRING]");
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
