using Domain.Officers.Departments;


namespace Infrastructure.Data.Configuration;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.Property(x => x.Name)
               .HasColumnType("VARCHAR(30)")
               .IsRequired();

        builder.ToTable("Departments");
#if DEBUG
        builder.HasData(SeedData.LoadDepartments());
#endif
    }


}
