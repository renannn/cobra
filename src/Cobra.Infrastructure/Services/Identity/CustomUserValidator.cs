﻿using Cobra.Common.GuardToolkit;
using Cobra.Core.Settings;
using Cobra.Entities.Administration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cobra.Infrastructure.Services.Identity
{
    /// <summary>
    /// Extending the Built-in User Validation
    /// More info: http://www.dotnettips.info/post/2579
    /// </summary>
    public class CustomUserValidator : UserValidator<User>
    {
        private readonly ISet<string> _emailsBanList;

        public CustomUserValidator(
            IdentityErrorDescriber errors,// How to use CustomIdentityErrorDescriber
            IOptionsSnapshot<SiteSettings> configurationRoot
            ) : base(errors)
        {
            if (configurationRoot == null) throw new ArgumentNullException(nameof(configurationRoot));
            _emailsBanList = new HashSet<string>(configurationRoot.Value.EmailsBanList, StringComparer.OrdinalIgnoreCase);

            if (!_emailsBanList.Any())
            {
                throw new InvalidOperationException("Please fill the emails ban list in the appsettings.json file.");
            }
        }

        public override async Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
        {
            // First use the built-in validator
            var result = await base.ValidateAsync(manager, user);
            var errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();

            // Extending the built-in validator
            validateEmail(user, errors);
            validateUserName(user, errors);

            return !errors.Any() ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
        }

        private void validateEmail(User user, List<IdentityError> errors)
        {
            var userEmail = user?.Email;
            if (string.IsNullOrWhiteSpace(userEmail))
            {
                if (string.IsNullOrWhiteSpace(userEmail))
                {
                    errors.Add(new IdentityError
                    {
                        Code = "EmailIsNotSet",
                        Description = "Por favor, complete as informações de e-mail."
                    });
                }
                return; // base.ValidateAsync() will cover this case
            }

            if (_emailsBanList.Any(email => userEmail.EndsWith(email, StringComparison.OrdinalIgnoreCase)))
            {
                errors.Add(new IdentityError
                {
                    Code = "BadEmailDomainError",
                    Description = "Por favor, insira um e-mail de encaminhamento válido."
                });
            }
        }

        private static void validateUserName(User user, List<IdentityError> errors)
        {
            var userName = user?.UserName;
            if (string.IsNullOrWhiteSpace(userName))
            {
                if (string.IsNullOrWhiteSpace(userName))
                {
                    errors.Add(new IdentityError
                    {
                        Code = "UserIsNotSet",
                        Description = "Por favor, complete as credenciais."
                    });
                }
                return;  // base.ValidateAsync() will cover this case
            }

            if (userName.IsNumeric() || userName.ContainsNumber())
            {
                errors.Add(new IdentityError
                {
                    Code = "BadUserNameError",
                    Description = "O nome de usuário inserido não pode conter números."
                });
            }

            if (userName.HasConsecutiveChars())
            {
                errors.Add(new IdentityError
                {
                    Code = "BadUserNameError",
                    Description = "O nome de usuário inserido não é válido."
                });
            }
        }
    }
}