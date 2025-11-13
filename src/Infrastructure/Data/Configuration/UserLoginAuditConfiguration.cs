using Domain.Users;

namespace Infrastructure.Data.Configuration;

public class UserLoginLogConfiguration : IEntityTypeConfiguration<UserLoginLog>
{
    public void Configure(EntityTypeBuilder<UserLoginLog> builder)
    {
        builder.Property(x => x.LoginTime)
               .IsRequired();

        builder.Property(x => x.IPAddress)
               .HasColumnType("VARCHAR")
               .HasMaxLength(45) // Max length for IPv6
               .IsFixedLength()
               .IsRequired();

        builder.Property(x => x.DeviceInfo)
               .HasMaxLength(100)
               .HasColumnType("VARCHAR")
               .IsRequired();

        builder.Property(x => x.IsSuccessful)
               .IsRequired();

        builder.Property(x => x.Username)
               .HasColumnType("VARCHAR")
               .HasMaxLength(20)
               .IsRequired();

        builder.HasOne(x => x.UserInfo)
               .WithMany()
               .HasForeignKey(x => x.UserId)
               .IsRequired();

        builder.ToTable("UserLoginLogs");
#if DEBUG
        builder.HasData(SeedData.LoadUserLoginAudits());
#endif
    }


}
