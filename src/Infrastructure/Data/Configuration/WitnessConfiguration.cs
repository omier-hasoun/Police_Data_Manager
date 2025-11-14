using Domain.Cases.Witnesses;

namespace Infrastructure.Data.Configuration;

public class WitnessConfiguration : IEntityTypeConfiguration<Witness>
{
    public void Configure(EntityTypeBuilder<Witness> builder)
    {
        builder.Property(x => x.Statements)
               .HasMaxLength(255)
               .IsRequired();

        builder.HasOne(x => x.CitizenInfo)
               .WithMany()
               .HasForeignKey(x => x.CitizenId)
               .IsRequired();

        builder.HasOne(x => x.WitnessedForCase)
               .WithMany(x => x.Witnesses)
               .HasForeignKey(x => x.CaseId)
               .IsRequired();

        builder.ToTable("Witnesses");
#if DEBUG
        // builder.HasData(SeedData.LoadWitnesses());
#endif
    }

}
