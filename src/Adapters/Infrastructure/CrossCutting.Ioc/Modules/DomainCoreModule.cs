using Arch.Domain.Commands;
using Arch.Domain.Core.Notifications;
using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;

namespace Arch.Infrastructure.CrossCutting.Ioc.Modules {
    public class DomainCoreModule : Module {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(DomainNotificationHandler).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.AddMediatR(typeof(DomainNotificationHandler).Assembly);

        }
    }
}
