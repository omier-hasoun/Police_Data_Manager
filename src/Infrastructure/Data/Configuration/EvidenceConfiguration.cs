using Domain.Cases.Evidences;

namespace Infrastructure.Data.Configuration;

public class EvidenceConfiguration : IEntityTypeConfiguration<Evidence>
{
    public void Configure(EntityTypeBuilder<Evidence> builder)
    {
        builder.HasOne(x => x.Case)
               .WithMany(x => x.Evidences)
               .HasForeignKey(x => x.CaseId)
               .IsRequired();

        builder.Property(x => x.CollectionMethod)
               .HasConversion<string>()
               .IsRequired();

        builder.Property(x => x.Type)
               .HasConversion<string>()
               .IsRequired();

        builder.Property(x => x.Description)
               .HasMaxLength(500)
               .IsRequired();

        builder.ToTable("Evidences");
#if DEBUG
        builder.HasData(SeedData.LoadEvidences());
#endif
    }

}
