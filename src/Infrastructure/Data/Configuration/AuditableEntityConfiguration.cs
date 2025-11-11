using Domain.Common.Abstractions;

namespace Infrastructure.Data.Configuration;

public class AuditableEntityConfiguration : IEntityTypeConfiguration<AuditableEntity>
{
    public void Configure(EntityTypeBuilder<AuditableEntity> builder)
    {
        builder.Property(a => a.CreatedBy)
               .HasMaxLength(30)
               .IsRequired();

        builder.Property(a => a.LastModifiedBy)
               .HasMaxLength(30)
               .IsRequired();

        builder.Property(a => a.CreatedAtUtc)
               .IsRequired();

        builder.Property(a => a.LastModifiedAtUtc)
               .IsRequired();

        builder.UseTpcMappingStrategy();
    }
}
