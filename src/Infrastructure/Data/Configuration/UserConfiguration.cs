using Domain.Users;


namespace Infrastructure.Data.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Username)
               .HasColumnType("VARCHAR")
               .HasMaxLength(20)
               .IsRequired();

        builder.Property(x => x.PasswordHash)
               .HasColumnType("VARCHAR")
               .HasMaxLength(256)
               .IsRequired();

        builder.Property(x => x.IsActive)
               .IsRequired();

        builder.Property(x => x.LockTime);

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
        builder.HasData(SeedData.LoadUsers());
#endif
    }

}
