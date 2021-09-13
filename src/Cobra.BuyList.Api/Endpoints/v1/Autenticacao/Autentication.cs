using Ardalis.ApiEndpoints;
using Cobra.Core.Settings;
using Cobra.Infrastructure.Services.Contracts.Identity;
using Cobra.Infrastructure.Services.Identity;
using Cobra.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cobra.BuyList.Api.Endpoints.v1.Autenticacao
{
    [AllowAnonymous]
    public class Autentication : BaseAsyncEndpoint
        .WithRequest<LoginRequest>
        .WithResponse<TokenResult>
    {
        private readonly ILogger<Autentication> _logger;
        private readonly IApplicationSignInManager _signInManager;
        private readonly IApplicationUserManager _userManager;
        private readonly IOptionsSnapshot<SiteSettings> _siteOptions;
        private readonly IJWT _jwt;


        public Autentication(IOptionsSnapshot<SiteSettings> siteOptions,
            IApplicationSignInManager signInManager,
            IApplicationUserManager userManager,
            ILogger<Autentication> logger,
            IJWT jwt)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _siteOptions = siteOptions ?? throw new ArgumentNullException(nameof(siteOptions));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _jwt = jwt ?? throw new ArgumentNullException(nameof(jwt));
        }

        [HttpPost("/v1/auth")]
        [SwaggerOperation(
                 Summary = "",
                 Description = "",
                 OperationId = "Autenticacao.CreateToken",
                 Tags = new[] { "AutenticacaoEndpoints" })]
        public override async Task<ActionResult<TokenResult>> HandleAsync(LoginRequest request, CancellationToken cancellationToken = default)
        {
            if (Request == null) return Unauthorized();

            try
            {
                if (await _jwt.ValidateCredentialsAsync(request))
                {
                    return await _jwt.BuildJWTTokenAsync(request);
                }
                else
                {
                    return BadRequest(new
                    {
                        Authenticated = false,
                        Message = "Falha ao autenticar"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
