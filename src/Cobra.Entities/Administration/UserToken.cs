using Cobra.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;

namespace Cobra.Entities.Administration
{
    public class UserToken : IdentityUserToken<Guid>,
        IHasId<Guid>,
        IBaseEntity
    {
        public virtual User User { get; set; }
        public DateTime AccessTokenExpiresDateTime { get; set; }
        public string AccessTokenHash { get; set; }
        public string RefreshTokenIdHash { get; set; }
        public DateTimeOffset RefreshTokenExpiresDateTime { get; set; }
        public Guid Id { get; set; }
    }
}
