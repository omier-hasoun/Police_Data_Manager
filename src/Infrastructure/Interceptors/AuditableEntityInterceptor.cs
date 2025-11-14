using Domain.Common.Abstractions;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Interceptors;

public sealed class AuditableEntitySaveChangesInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        if (eventData.Context is null)
            return ValueTask.FromResult(result);

        var entries = eventData.Context.ChangeTracker.Entries<AuditableEntity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                // entry.Entity.SetCreated("");
                continue;
            }

            if (entry.State == EntityState.Modified)
            {
                // entry.Entity.SetModified("")
            }
        }
        // do i need to return base.SavingChangesAsync if i have multiple saveChangesInterceptors ?

        return ValueTask.FromResult(result);
    }
}
