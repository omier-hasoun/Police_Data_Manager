
using Domain.Cases;
using Domain.Citizens;
using Domain.Cases.Evidences;
using Domain.Officers;
using Domain.Cases.Witnesses;
using Domain.Users;
using Domain.States;
using Domain.Officers.Departments;
using Infrastructure.Data.Configuration;

namespace Infrastructure.Data;

public sealed class AppDbContext : DbContext, IAppDbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }

    public AppDbContext()
    {
    }

    public DbSet<Case> Cases => Set<Case>();
    public DbSet<Evidence> Evidences => Set<Evidence>();
    public DbSet<Officer> Officers => Set<Officer>();
    public DbSet<Citizen> Citizens => Set<Citizen>();
    public DbSet<Witness> Witnesses => Set<Witness>();
    public DbSet<CaseParticipant> CaseParticipants => Set<CaseParticipant>();
    public DbSet<User> Users => Set<User>();
    public DbSet<State> States => Set<State>();
    public DbSet<UserLoginLog> UserLoginAudits => Set<UserLoginLog>();
    public DbSet<Department> Departments => Set<Department>();

    public override async Task<int> SaveChangesAsync(CancellationToken token)
    {
        // var entries = ChangeTracker.Entries<AuditableEntity>();
        // foreach (var entry in entries)
        // {
        //     // e.g. set audit fields
        //     if (entry.State == EntityState.Added)
        //     {
        //         entry.Entity.SetCreated("omier");
        //     }
        //     else if (entry.State == EntityState.Modified)
        //     {
        //         entry.Entity.SetModified("omier");
        //     }
        // }

        return await base.SaveChangesAsync(token);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasSequence<int>("OfficerBadgeNumberSeq", schema: "dbo")
                    .StartsAt(10000)
                    .IncrementsBy(1)
                    .IsCyclic();

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityConfiguration).Assembly);
    }
}
