using Autofac;
using Autofac.Core;
using Nl.Core.Configuration;
using Nl.Core.Data;
using Nl.Core.Infrastructure;
using Nl.Core.Infrastructure.DependencyManagement;
using Nop.Data;
using Nop.Plugin.Pickup.PickupInStore.Data;
using Nop.Plugin.Pickup.PickupInStore.Domain;
using Nop.Plugin.Pickup.PickupInStore.Services;
using Nl.WebFramework.Infrastructure.Extensions;

namespace Nop.Plugin.Pickup.PickupInStore.Infrastructure
{
    /// <summary>
    /// Dependency registrar
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            builder.RegisterType<StorePickupPointService>().As<IStorePickupPointService>().InstancePerLifetimeScope();

            //data context
            builder.RegisterPluginDataContext<StorePickupPointObjectContext>("nop_object_context_pickup_in_store-pickup");

            //override required repository with our custom context
            builder.RegisterType<EfRepository<StorePickupPoint>>().As<IRepository<StorePickupPoint>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>("nop_object_context_pickup_in_store-pickup"))
                .InstancePerLifetimeScope();
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order => 1;
    }
}