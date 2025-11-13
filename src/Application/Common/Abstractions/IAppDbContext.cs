
using Domain.Cases.Witnesses;
using Domain.Officers.Departments;
using Domain.States;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Abstractions;

public interface IAppDbContext
{
    public DbSet<Case> Cases { get; }
    public DbSet<Evidence> Evidences { get; }
    public DbSet<Officer> Officers { get; }
    public DbSet<Citizen> Citizens { get; }
    public DbSet<Witness> Witnesses { get; }
    public DbSet<CaseParticipant> CaseParticipants { get; }
    public DbSet<User> Users { get; }
    public DbSet<State> States { get; }
    public DbSet<UserLoginLog> UserLoginAudits { get; }
    public DbSet<Department> Departments { get; }

    Task<int> SaveChangesAsync(CancellationToken token);

}
