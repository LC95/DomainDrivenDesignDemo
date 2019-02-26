using Arch.Infrastructure.CrossCutting.Identity.Models;
using Arch.Infrastructure.CrossCutting.Identity.Services;
using Autofac;

namespace Arch.Infrastructure.CrossCutting.Ioc.Modules {
    public class IdentityModule : Module {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(AspNetUser).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.RegisterType<AuthEmailMessageSender>().As<IEmailSender>().InstancePerDependency();
            builder.RegisterType<AuthSMSMessageSender>().As<ISmsSender>().InstancePerDependency();
        }
    }
}
