
using Domain.Cases;

namespace Infrastructure.Data.Configuration;

public class CaseParticipantConfiguration : IEntityTypeConfiguration<CaseParticipant>
{
    public void Configure(EntityTypeBuilder<CaseParticipant> builder)
    {
        builder.HasOne(x => x.Case)
               .WithMany(x => x.Participants)
               .HasForeignKey(x => x.CaseId)
               .IsRequired()
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.CitizenInfo)
               .WithMany()
               .HasForeignKey(x => x.CitizenId)
               .IsRequired();

        builder.Property(x => x.Role)
               .HasConversion<string>()
               .HasMaxLength(20)
               .IsRequired();

        builder.ToTable("CaseParticipants");
#if DEBUG
        builder.HasData(SeedData.LoadCaseParticipants());
#endif

    }


}
