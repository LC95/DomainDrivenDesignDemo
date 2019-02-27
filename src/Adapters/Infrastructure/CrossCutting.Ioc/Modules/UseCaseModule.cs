using Arch.Domain.Core.Notifications;
using Arch.Domain.EventHandler;
using Arch.Domain.Events;
using Arch.UseCase.AutoMapper;
using Autofac;
using AutoMapper.Extensions.Autofac.DependencyInjection;
using MediatR;

namespace Arch.Infrastructure.CrossCutting.Ioc.Modules {
    public class UseCaseModule : Module {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<INotificationHandler<DomainNotification>>().As<DomainNotificationHandler>().InstancePerLifetimeScope();
            //builder.RegisterType<INotificationHandler<CustomerRegisteredEvent>>().As<CustomerEventHandler>().InstancePerLifetimeScope();
            //builder.RegisterType<INotificationHandler<CustomerUpdatedEvent>>().As<CustomerEventHandler>().InstancePerLifetimeScope();
            //builder.RegisterType<INotificationHandler<CustomerRemovedEvent>>().As<CustomerEventHandler>().InstancePerLifetimeScope();
            builder.AddAutoMapper(typeof(AutoMapperConfig).Assembly);
            builder.RegisterAssemblyTypes(typeof(AutoMapperConfig).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            
        }
    }
}
