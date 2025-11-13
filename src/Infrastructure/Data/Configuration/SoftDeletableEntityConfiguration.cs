using Domain.Common.Abstractions;

namespace Infrastructure.Data.Configuration;

public class SoftDeletableEntityConfiguration : IEntityTypeConfiguration<SoftDeletableEntity>
{
    public void Configure(EntityTypeBuilder<SoftDeletableEntity> builder)
    {
        builder.Property(a => a.DeletedByUsername)
               .HasColumnType("VARCHAR(20)");

        builder.UseTpcMappingStrategy();
    }
}
