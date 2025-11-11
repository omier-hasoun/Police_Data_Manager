using Domain.Officers;
using Domain.States;
using Microsoft.Identity.Client;

namespace Infrastructure.Data.Configuration;

public class OfficerConfiguration : IEntityTypeConfiguration<Officer>
{
    public void Configure(EntityTypeBuilder<Officer> builder)
    {
        builder.Property(x => x.FirstName)
               .HasColumnType("VARCHAR(50)")
               .IsRequired();

        builder.Property(x => x.LastName)
               .HasColumnType("VARCHAR(50)")
               .IsRequired();

        builder.Property(x => x.Email)
               .HasColumnType("VARCHAR(254)")
               .IsRequired();

        builder.Property(x => x.Phone)
               .HasColumnType("CHAR(15)")
               .IsRequired();

        builder.Property(x => x.Rank)
               .HasConversion<string>()
               .HasMaxLength(20)
               .IsRequired();

        builder.Property(x => x.BadgeNumber)
               .HasConversion(
                   v => v.Value,
                   v => new OfficerBadgeNumber(v))
               .HasColumnType("CHAR(10)")
               .IsRequired();

        builder.HasOne(x => x.Department)
               .WithMany()
               .HasForeignKey(x => x.DepartmentId)
               .IsRequired();

        builder.HasOne(x => x.InState)
               .WithMany()
               .HasForeignKey(x => x.InStateId)
               .IsRequired();

        builder.HasIndex(x => new { x.FirstName, x.LastName })
               .HasDatabaseName("IX_Officer_FullName");

        builder.ToTable("Officers");
#if DEBUG
        builder.HasData(SeedData.LoadOfficers());
#endif
    }

}
