using Epay.Persistence;
using Epay.ReadModel.Context;
using Framework.Application;
using Framework.Core.Acl;
using Framework.Core.Application;
using Framework.Core.DependencyInjection;
using Framework.Core.Domain;
using Framework.Core.Mapper;
using Framework.Core.Persistence;
using Framework.Core.PushNotification;
using Framework.Persistence;
using Framework.PushNotification;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.DependencyInjection
{
    public abstract class RegistrarBase<TRegister> : IRegistrar
    {
        private readonly AssemblyHelper.AssemblyHelper assemblyHelper;

        protected RegistrarBase()
        {
            var nameSpaceSpell = typeof(TRegister).Namespace.Split('.');
            var schemaName = nameSpaceSpell[0] + "." + nameSpaceSpell[1];
            assemblyHelper = new AssemblyHelper.AssemblyHelper(schemaName);
        }

        public virtual void Register(IServiceCollection services, string connectionString)
        {
            RegisterPersistence(services, connectionString);
            RegisterFramework(services);
            RegisterRepositories(services);
            RegisterServices(services);
            RegisterAclServices(services);
            RegisterCommandHandlers(services);
        }

        private void RegisterPersistence(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<IDbContext, EpayDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddDbContext<EpayContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        }

        private void RegisterFramework(IServiceCollection services)
        {
            services.AddSingleton<IMapper, Mapper.Mapper>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEventBus, EventBus>();
            services.AddScoped<IDiContainer, DiContainer>();
            services.AddTransient(typeof(IEntityIdGenerator<>), typeof(EntityIdGenerator<>));
            services.AddScoped<ICommandBus, CommandBus>();
            services.AddTransient<INotificationFactory, NotificationFactory>();
        }

        private void RegisterRepositories(IServiceCollection services)
        {
            var repositories = assemblyHelper.GetTypes(typeof(RepositoryBase<>)).ToList();
            repositories.AddRange(assemblyHelper.GetTypes(typeof(DbFirstRepositoryBase)));
            foreach (var repository in repositories)
            {
                var baseInterfaces = repository.GetInterfaces().Where(a => a.IsGenericType == false);
                foreach (var baseInterface in baseInterfaces)
                    services.AddScoped(baseInterface, repository);
            }
        }

        private void RegisterServices(IServiceCollection services)
        {
            var domainServices = assemblyHelper.GetClassByInterface(typeof(IDomainService))
                .Where(a => a.IsInterface == false);

            foreach (var service in domainServices)
            {
                var baseInterface = service.GetInterfaces().Single(a => a.GetMembers().Any());
                services.AddTransient(baseInterface, service);
            }
        }

        private void RegisterAclServices(IServiceCollection services)
        {
            var domainServices = assemblyHelper.GetClassByInterface(typeof(IAntiCorruptionLayer))
                .Where(a => a.IsInterface == false);

            foreach (var service in domainServices)
            {
                var baseInterface = service.GetInterfaces().Single(a => a.GetMembers().Any());
                services.AddTransient(baseInterface, service);
            }
        }

        private void RegisterCommandHandlers(IServiceCollection services)
        {
            var commandHandlers = assemblyHelper.GetClassByInterface(typeof(ICommandHandler<>));
            foreach (var commandHandler in commandHandlers)
            {
                var baseInterface = commandHandler.GetInterfaces()[0];
                services.AddScoped(baseInterface, commandHandler);
            }
        }

    }
}
