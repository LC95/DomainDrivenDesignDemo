using Autofac;

namespace Arch.Queries {
    public class Module : Autofac.Module {
        public string ConnectionString { get; set; }
        protected override void Load(ContainerBuilder builder)
        {
        }
    }
}
