
namespace Domain.Common.Abstractions;

public abstract class Entity
{
    public Guid Id { get; private set; } // db generated id
    private readonly List<DomainEvent> _domainEvents = [];

    private Entity()
    {
    }

    protected Entity(Guid id = default)
    {
        if (id == default)
        {
            Id = Guid.CreateVersion7();
        }
        else
        {
            Id = id;
        }

    }


    public void AddDomainEvent(DomainEvent domainEvent)
    {
        if (domainEvent is null)
            return;

        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents(DomainEvent domainEvent)
    {
        _domainEvents.Clear();
    }


}
