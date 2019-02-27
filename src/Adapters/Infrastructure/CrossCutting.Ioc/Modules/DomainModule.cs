using Arch.Domain.Entities;
using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using Module = Autofac.Module;

namespace Arch.Infrastructure.CrossCutting.Ioc.Modules {
    public class DomainModule : Module {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Customer).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.AddMediatR(typeof(Customer).Assembly);

        }
    }
}
