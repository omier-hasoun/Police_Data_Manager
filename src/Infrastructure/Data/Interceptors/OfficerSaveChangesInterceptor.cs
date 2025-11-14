using Domain.Officers;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Data.Interceptors;

public class OfficerSaveChangesInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        if (eventData.Context is null)
            return ValueTask.FromResult(result);

        var officersEntries = eventData.Context.ChangeTracker.Entries<Officer>();

        foreach (var entry in officersEntries)
        {
            if (entry is { State: EntityState.Added })
            {
                // entry.Entity.AssignBadgeNumber();
            }
        }

        return ValueTask.FromResult(result);
    }
}
