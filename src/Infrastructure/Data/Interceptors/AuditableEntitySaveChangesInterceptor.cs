using Domain.Common.Abstractions;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Data.Interceptors;

public sealed class AuditableEntitySaveChangesInterceptor : SaveChangesInterceptor
{
    private readonly ICurrentUserService _currentUser;

    public AuditableEntitySaveChangesInterceptor(ICurrentUserService currentUser)
    {
        _currentUser = currentUser;
    }
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        if (eventData.Context is null)
            return ValueTask.FromResult(result);

        var entries = eventData.Context.ChangeTracker.Entries<AuditableEntity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.SetCreated(_currentUser.Username);
                continue;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Entity.SetModified(_currentUser.Username);
            }
        }

        return ValueTask.FromResult(result);
    }
}
