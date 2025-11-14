using Domain.Common.Abstractions;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Data.Interceptors;

public sealed class SoftDeletableEntitySaveChangesInterceptor(ICurrentUserService currentUser) : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        if (eventData.Context is null)
            return ValueTask.FromResult(result);

        var entries = eventData.Context.ChangeTracker.Entries<SoftDeletableEntity>();

        foreach (var entry in entries)
        {
            if (entry is not { State: EntityState.Deleted })
            {
                continue;
            }
            entry.State = EntityState.Modified;

            entry.Entity.Delete(currentUser.Username);
        }

        return ValueTask.FromResult(result);
    }
}
