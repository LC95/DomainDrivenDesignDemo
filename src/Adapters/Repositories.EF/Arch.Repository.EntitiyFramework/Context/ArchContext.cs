using Arch.Domain.Entities;
using Arch.Repository.EntityFramework.Mappings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Arch.Repository.EntityFramework.Context {
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
