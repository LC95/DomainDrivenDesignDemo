using Arch.Domain.Core.Events;
using Arch.Repository.EntityFramework.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Arch.Repository.EntityFramework.Context {
    public class EventStoreSqlContext : DbContext {
        public DbSet<StoredEvent> StoredEvent { get; set; }

        public EventStoreSqlContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoredEventMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
