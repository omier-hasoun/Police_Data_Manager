
using Domain.Cases;
using Domain.Citizens;
using Domain.Cases.Evidences;
using Domain.Officers;
using Domain.Cases.Witnesses;
using Domain.Users;
using Domain.States;
using Domain.Officers.Departments;
using Domain.Common.Abstractions;
using Infrastructure.Data.Configuration;

namespace Infrastructure.Data;

public sealed class AppDbContext : DbContext, IAppDbContext
{

    public DbSet<Case> Cases => Set<Case>();
    public DbSet<Evidence> Evidences => Set<Evidence>();
    public DbSet<Officer> Officers => Set<Officer>();
    public DbSet<Citizen> Citizens => Set<Citizen>();
    public DbSet<Witness> Witnesses => Set<Witness>();
    public DbSet<CaseParticipant> CaseParticipants => Set<CaseParticipant>();
    public DbSet<User> Users => Set<User>();
    public DbSet<State> States => Set<State>();
    public DbSet<UserLoginAudit> UserLoginAudits => Set<UserLoginAudit>();
    public DbSet<Department> Departments => Set<Department>();

    public override async Task<int> SaveChangesAsync(CancellationToken token)
    {
        var entries = ChangeTracker.Entries<AuditableEntity>();
        foreach (var entry in entries)
        {
            // e.g. set audit fields
            if (entry.State == EntityState.Added)
            {
                entry.Entity.ORMCreated("omier");
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.ORMModified("omier");
            }
        }

        return await base.SaveChangesAsync(token);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        // If options are already configured (for example via DI with AddDbContext), do nothing.
        if (optionsBuilder.IsConfigured)
        {
            return;
        }

        // The context was not configured; throwing makes the situation explicit.
        // Configure the DbContext externally (e.g. in Program.cs/Startup.cs using AddDbContext with a connection string)
        // or override this method to provide configuration using public EF Core APIs.
        throw new InvalidOperationException("The DbContextOptions are not configured. Configure the context with a connection string via AddDbContext or override OnConfiguring to provide a connection string using public APIs.");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasSequence<int>("OfficerBadgeNumberSeq", schema: "dbo")
                    .StartsAt(1)
                    .IncrementsBy(1);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityConfiguration).Assembly);
    }
}
