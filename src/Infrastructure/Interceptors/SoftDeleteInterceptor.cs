using Domain.Common.Abstractions;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Interceptors;

public sealed class SoftDeleteSaveChangesInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        if (eventData.Context is null)
            return ValueTask.FromResult(result);

        var entries = eventData.Context.ChangeTracker.Entries();

        foreach (var entry in entries)
        {
            if (entry is not { State: EntityState.Deleted, Entity: SoftDeletableEntity entity })
            {
                continue;
            }
            entry.State = EntityState.Modified;

            // TODO: Implement entity.Delete() when Users manager is defined.
        }
        // do i need to return base.SavingChangesAsync if i have multiple saveChangesInterceptors ?

        return ValueTask.FromResult(result);
    }
}
