using Autofac;
using AutoMapper;
using Cobra.Common.Caching;
using Cobra.Entities.Administration;
using Cobra.Infrastructure.Data;
using Cobra.Infrastructure.Services.Contracts.Identity;
using Cobra.Infrastructure.Services.Identity;
using Cobra.Infrastructure.Services.Identity.Logger;
using Cobra.SharedKernel.Interfaces;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using Module = Autofac.Module;

namespace Cobra.Infrastructure.Autofac
{
    public class DefaultInfrastructureModule : Module
    {
        private readonly bool _isDevelopment;
        private readonly List<Assembly> _assemblies = new();

        public DefaultInfrastructureModule(bool isDevelopment, Assembly callingAssembly = null)
        {
            _isDevelopment = isDevelopment;
            var coreAssembly = Assembly.GetAssembly(typeof(Core.Dummy));
            var sharedKernelAssembly = Assembly.GetAssembly(typeof(SharedKernel.Dummy));
            var infrastructureAssembly = Assembly.GetAssembly(typeof(Dummy));
            _assemblies.Add(coreAssembly);
            _assemblies.Add(sharedKernelAssembly);
            _assemblies.Add(infrastructureAssembly);
            if (callingAssembly != null)
            {
                _assemblies.Add(callingAssembly);
            }
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (_isDevelopment)
            {
                RegisterDevelopmentOnlyDependencies(builder);
            }
            else
            {
                RegisterProductionOnlyDependencies(builder);
            }
            RegisterCommonDependencies(builder);
        }

        private void RegisterCommonDependencies(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CustomNormalizer>()
                .As<ILookupNormalizer>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CustomSecurityStampValidator>()
                .As<ISecurityStampValidator>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CustomSecurityStampValidator>()
                .As<SecurityStampValidator<User>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CustomPasswordValidator>()
                .As<IPasswordValidator<User>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CustomPasswordValidator>()
                .As<PasswordValidator<User>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CustomUserValidator>()
                .As<IUserValidator<User>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CustomUserValidator>()
                .As<UserValidator<User>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationClaimsPrincipalFactory>()
                .As<IUserClaimsPrincipalFactory<User>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<JWT>()
                .As<IJWT>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationClaimsPrincipalFactory>()
                .As<UserClaimsPrincipalFactory<User, Role>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CustomIdentityErrorDescriber>()
                .As<IdentityErrorDescriber>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationUserStore>()
                .As<IApplicationUserStore>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationUserStore>()
                .As<UserStore<User, Role, AppDbContext, Guid, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationUserManager>()
                .As<IApplicationUserManager>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationUserManager>()
                .As<UserManager<User>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationRoleManager>()
                .As<IApplicationRoleManager>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationRoleManager>()
                .As<RoleManager<Role>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationSignInManager>()
                .As<IApplicationSignInManager>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationSignInManager>()
                .As<SignInManager<User>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationRoleStore>()
                .As<IApplicationRoleStore>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationRoleStore>()
                .As<RoleStore<Role, AppDbContext, Guid, UserRole, RoleClaim>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AuthMessageSender>()
                .As<IEmailSender>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AuthMessageSender>()
                .As<ISmsSender>()
                .InstancePerLifetimeScope();

            builder.RegisterType<IdentityDbInitializer>()
                .As<IIdentityDbInitializer>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UsedPasswordsService>()
                .As<IUsedPasswordsService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SiteStatService>()
                .As<ISiteStatService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UsersPhotoService>()
                .As<IUsersPhotoService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SecurityTrimmingService>()
                .As<ISecurityTrimmingService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AppLogItemsService>()
                .As<IAppLogItemsService>()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Cache<>))
              .As(typeof(ICache<>))
              .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<,>))
              .As(typeof(IRepository<,>))
              .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(NoKeyRepository<>))
              .As(typeof(INoKeyRepository<>))
              .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(WriteRepository<,>))
              .As(typeof(IWriteRepository<,>))
              .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(ReadRepository<,>))
              .As(typeof(IReadRepository<,>))
              .InstancePerLifetimeScope();

            builder.RegisterType<TransationRepository>()
                .As<ITransationRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TokenValidatorService>()
                .As<ITokenValidatorService>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<SecurityService>()
                .As<ISecurityService>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<TokenValidatorService>()
                .As<ITokenValidatorService>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            var mediatrOpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(IRequestExceptionHandler<,,>),
                typeof(IRequestExceptionAction<,>),
                typeof(INotificationHandler<>),
            };

            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder
                .RegisterAssemblyTypes(_assemblies.ToArray())
                .AsClosedTypesOf(mediatrOpenType)
                .AsImplementedInterfaces();
            }

            RegisterAutomapperDefault(builder, _assemblies.ToArray());
        }

        private void RegisterAutomapperDefault(ContainerBuilder builder, IEnumerable<Assembly> assemblies)
        {
            builder
                .Register<IConfigurationProvider>(_ => new MapperConfiguration(cfg => cfg.AddMaps(assemblies)))
                .SingleInstance();

            builder
                .Register<IMapper>(ctx => new AutoMapper.Mapper(ctx.Resolve<IConfigurationProvider>(), ctx.Resolve))
                .InstancePerDependency();
        }

        private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
        {
            // TODO: Add development only services
        }

        private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
        {
            // TODO: Add production only services
        }
    }
}