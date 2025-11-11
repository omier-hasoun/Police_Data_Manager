
using System.ComponentModel;

namespace Domain.Common.Abstractions;

public abstract class AuditableEntity : Entity
{
    public DateTimeOffset CreatedAtUtc { get; private set; }
    public string CreatedBy { get; private set; } = string.Empty;
    public DateTimeOffset? LastModifiedAtUtc { get; private set; }
    public string? LastModifiedBy { get; private set; }

    private AuditableEntity()
    {

    }
    protected AuditableEntity(Guid id = default) : base(id)
    {
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void ORMModified(string username)
    {
        this.LastModifiedBy = username;
        this.LastModifiedAtUtc = DateTimeOffset.UtcNow;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void ORMCreated(string username)
    {
        this.CreatedBy = username;
        this.CreatedAtUtc = DateTimeOffset.UtcNow;
    }
}
