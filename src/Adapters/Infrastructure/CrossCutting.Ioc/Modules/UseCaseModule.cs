using Arch.UseCase.AutoMapper;
using Autofac;

namespace Arch.Infrastructure.CrossCutting.Ioc.Modules {
    public class UseCaseModule : Module {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(AutoMapperConfig).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
