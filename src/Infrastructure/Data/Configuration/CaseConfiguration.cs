using Domain.Cases;

namespace Infrastructure.Data.Configuration;

public class CaseConfiguration : IEntityTypeConfiguration<Case>
{
    public void Configure(EntityTypeBuilder<Case> builder)
    {

        builder.Property(x => x.Title)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(x => x.Description)
               .HasMaxLength(550)
               .IsRequired();

        builder.Property(x => x.ProgressReport)
               .HasMaxLength(1000)
               .IsRequired(required: false);

        builder.Property(x => x.FinalReport)
               .HasMaxLength(500)
               .IsRequired(required: false);

        builder.Property(x => x.Status)
               .HasConversion<string>()
               .HasMaxLength(30)
               .IsRequired();

        builder.Property(x => x.Type)
               .HasConversion<string>()
               .HasMaxLength(30)
               .IsRequired();

        builder.Property(x => x.ClosedAt)
               .IsRequired(required: false);

        builder.Property(x => x.IncidentDate)
               .IsRequired(required: false);

        builder.Property(x => x.InvestigationStartedAt)
               .IsRequired(required: false);

        builder.HasIndex(x => x.IncidentDate)
               .HasDatabaseName("IX_IncidentDate");

        builder.Ignore(x => x.Accuseds);// they will be filtered from the participants field collection
        builder.Ignore(x => x.Perpetrators);
        builder.Ignore(x => x.Suspects);
        builder.Ignore(x => x.Victims);

        builder.ToTable(
            "Cases",
            t =>
            {
                t.HasCheckConstraint
                (
                    "CK_ClosedAt",
                    "ClosedAt > IncidentDate and InvestigationStartedAt is null or ClosedAt > InvestigationStartedAt and ClosedAt <= GETUTCDATE()"
                );
                t.HasCheckConstraint
                (
                    "CK_InvestigationStartedAt",

                    "IncidentDate is null or InvestigationStartedAt > IncidentDate and ClosedAt is null"
                );
                t.HasCheckConstraint
                (
                    "CK_IncidentDate",

                    "IncidentDate < InvestigationStartedAt and IncidentDate <= GETUTCDATE()"
                );
            }
            );

#if DEBUG
        builder.HasData(SeedData.LoadCases());
#endif
    }

}
