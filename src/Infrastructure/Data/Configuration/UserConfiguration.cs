using Domain.Users;


namespace Infrastructure.Data.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Username)
               .HasColumnType("VARCHAR(20)")
               .IsRequired();

        builder.Property(x => x.PasswordHash)
               .HasColumnType("VARCHAR(128)")
               .IsRequired();

        builder.Property(x => x.IsActive)
               .IsRequired();

        builder.Property(x => x.LockStartTime)
               .IsRequired(false);

        builder.Property(x => x.LockedUntil)
               .IsRequired(false);

        builder.Property(x => x.IsLocked)
               .IsRequired();

        builder.Property(x => x.FailedLoginAttemptsCount)
               .IsRequired();

        builder.HasOne(x => x.OfficerInfo)
               .WithOne(x => x.UserInfo)
               .HasForeignKey<User>(x => x.OfficerId)
               .IsRequired();


        builder.ToTable("Users");
#if DEBUG
       // builder.HasData(SeedData.LoadUsers());
#endif
    }

}
