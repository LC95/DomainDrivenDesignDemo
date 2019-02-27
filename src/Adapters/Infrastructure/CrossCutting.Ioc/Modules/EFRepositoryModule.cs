using Arch.Data.EntityFramework.Context;
using Arch.Data.EntityFramework.UoW;
using Autofac;
using Microsoft.EntityFrameworkCore;

namespace Arch.Infrastructure.CrossCutting.Ioc.Modules {
    public class EfRepositoryModule : Module {
        public string ConnectionString { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
            optionsBuilder.UseSqlServer(ConnectionString);
            optionsBuilder.EnableSensitiveDataLogging(true);

            builder.RegisterType<ArchContext>()
              .WithParameter(new TypedParameter(typeof(DbContextOptions), optionsBuilder.Options))
              .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(UnitOfWork).Assembly)
                .WithParameter("connectionString", ConnectionString)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
