using Domain.States;

namespace Infrastructure.Data.Configuration;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.Property(x => x.Name)
               .HasColumnType("Varchar(30)")
               .IsRequired();

        builder.Property(x => x.Code)
               .HasColumnType("CHAR")
               .HasMaxLength(3)
               .IsRequired();

        builder.ToTable("States");
#if DEBUG
        // builder.HasData(SeedData.LoadStates());
#endif
    }


}
