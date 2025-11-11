using Domain.Common.Abstractions;

namespace Infrastructure.Data.Configuration;

public class EntityConfiguration : IEntityTypeConfiguration<Entity>
{
    public void Configure(EntityTypeBuilder<Entity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .ValueGeneratedOnAdd();

        builder.UseTpcMappingStrategy();
    }
}
