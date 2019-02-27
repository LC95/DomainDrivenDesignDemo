using Autofac;

namespace Arch.Infrastructure.CrossCutting.Ioc.Modules {
    public class InfrastructureModule : Module {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterAssemblyTypes(typeof(GuidIdGenerator).Assembly)
            //    .AsImplementedInterfaces()
            //    .InstancePerLifetimeScope();

        }
    }
}
