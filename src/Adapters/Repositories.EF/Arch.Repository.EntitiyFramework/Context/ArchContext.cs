using Arch.Data.EntityFramework.Mappings;
using Arch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arch.Data.EntityFramework.Context {
    public class ArchContext : DbContext {
        public ArchContext(DbContextOptions options) : base(options)
        {
           
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
