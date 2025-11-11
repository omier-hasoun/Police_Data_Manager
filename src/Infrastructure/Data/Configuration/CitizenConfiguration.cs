using Domain.Citizens;

namespace Infrastructure.Data.Configuration;

public class CitizenConfiguration : IEntityTypeConfiguration<Citizen>
{
    public void Configure(EntityTypeBuilder<Citizen> builder)
    {
        builder.Property(x => x.FirstName)
               .HasColumnType("VARCHAR")
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(x => x.LastName)
               .HasColumnType("VARCHAR")
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(x => x.NationalId)
               .HasConversion(NationalId => NationalId!.Value, Value => new CitizenNationalId(Value))
               .HasMaxLength(11)
               .IsRequired();

        builder.Property(x => x.DateOfBirth)
               .IsRequired();

        builder.Property(x => x.FullAddress)
               .HasMaxLength(150)
               .IsRequired();

        builder.Property(x => x.Phone)
               .HasMaxLength(16)
               .IsFixedLength()
               .IsRequired(false);

        builder.Property(x => x.IsAlive)
               .IsRequired();


        builder.HasIndex(x => new
        {
            x.FirstName,
            x.LastName
        }).HasDatabaseName("IX_Citizen_FullName");

        builder.ToTable(
            "Citizens",
            t =>
            {
                t.HasCheckConstraint(
                    "CK_DateOfBirth",
                    "DateOfBirth <= GETUTCDATE() and DateOfBirth > DateAdd(YEAR, -110, GETUTCDATE())"
                );
            });
#if DEBUG
        builder.HasData(SeedData.LoadCitizens());
#endif
    }


}
