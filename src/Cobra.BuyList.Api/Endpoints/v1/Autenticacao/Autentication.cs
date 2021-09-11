using Ardalis.ApiEndpoints;
using Cobra.Core.Settings;
using Cobra.Entities.Administration;
using Cobra.Infrastructure.Services.Contracts.Identity;
using Cobra.Infrastructure.Services.Identity;
using Cobra.Models.Identity;
using Cobra.SharedKernel.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cobra.BuyList.Api.Endpoints.v1.Autenticacao
{
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
                 Description = "Upload novo arquivo de importação",
                 OperationId = "Autenticacao.CreateToken",
                 Tags = new[] { "AutenticacaoEndpoints" })]
        public override async Task<ActionResult<TokenResult>> HandleAsync(LoginRequest request, CancellationToken cancellationToken = default)
        {
            if (Request == null) return Unauthorized();
            try
            {

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var validUser = await AuthenticateAsync(request);
            string tokenString;
            if (validUser != null)
            {
                tokenString = await _jwt.BuildJWTTokenAsync(validUser);
            }
            else
            {
                return Unauthorized();
            }
            return Ok(new { Token = tokenString });
        }
        private async Task<User> AuthenticateAsync(LoginRequest login)
        {
            var user = await _userManager.FindByNameAsync(login.Username);

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

            var result = await _signInManager.PasswordSignInAsync(
                                   login.Username,
                                   login.Password,
                                   false,
                                   lockoutOnFailure: true);
            if (result.Succeeded)
            {
                return user;
            }
            else
            {
                throw new Exception("Senha incorreta");
            }

        }

    }
}
