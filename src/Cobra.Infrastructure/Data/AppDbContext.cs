using Ardalis.EFCore.Extensions;
using Cobra.Common;
using Cobra.Entities.Administration;
using Cobra.Entities.AuditableEntity;
using EntityFramework.Exceptions.SqlServer;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;


namespace Cobra.Infrastructure.Data
{
    public partial class AppDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        private readonly IMediator _mediator;

        public AppDbContext(DbContextOptions<AppDbContext> options, IMediator mediator)
            : base(options)
        {

            _mediator = mediator;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();

            // Custom application mappings
            modelBuilder.SetDecimalPrecision();
            modelBuilder.AddDateTimeUtcKindConverter();

            // This should be placed here, at the end.
            modelBuilder.AddAuditableShadowProperties();
            modelBuilder.IgnoreField();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseExceptionProcessor()
                          .UseLazyLoadingProxies();
        }
    }
}