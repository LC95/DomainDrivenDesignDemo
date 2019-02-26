using Arch.Domain.Core.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arch.Repository.EntityFramework.Mappings {
    public class StoredEventMap : IEntityTypeConfiguration<StoredEvent> {
        public void Configure(EntityTypeBuilder<StoredEvent> builder)
        {
            builder.Property(c => c.CreateTime)
               .HasColumnName("CreateTime");

            builder.Property(c => c.MessageType)
                .HasColumnName("Action")
                .HasColumnType("varchar(100)");
        }
    }
}
