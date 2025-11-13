using Domain.Common.Abstractions;

namespace Infrastructure.Data.Configuration;

public class AuditableEntityConfiguration : IEntityTypeConfiguration<AuditableEntity>
{
    public void Configure(EntityTypeBuilder<AuditableEntity> builder)
    {
        builder.Property(a => a.CreatedByUsername)
               .HasColumnType("VARCHAR(20)");

        builder.Property(a => a.LastModifiedByUsername)
               .HasColumnType("VARCHAR(20)");

        builder.Property(a => a.CreatedAtUtc)
               .IsRequired();

        builder.Property(a => a.LastModifiedAtUtc)
               .IsRequired();

        builder.UseTpcMappingStrategy();
    }
}
