using Arch.Infrastructure.CrossCutting.Bus;
using Autofac;

namespace Arch.Infrastructure.CrossCutting.Ioc.Modules {
    public class BusModule : Module {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(InMemoryBus).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
