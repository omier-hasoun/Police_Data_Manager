

namespace Domain.Common.Abstractions;

public abstract class AuditableEntity : SoftDeletableEntity
{
    public DateTimeOffset CreatedAtUtc { get; private set; }
    public string CreatedByUsername { get; private set; } = string.Empty;
    public DateTimeOffset? LastModifiedAtUtc { get; private set; }
    public string? LastModifiedByUsername { get; private set; }


    private AuditableEntity()
    {

    }
    protected AuditableEntity(Guid id = default) : base(id)
    {
    }

    public void SetModified(string username)
    {
        this.LastModifiedByUsername = username;
        this.LastModifiedAtUtc = DateTimeOffset.UtcNow;
    }

    public void SetCreated(string username)
    {
        this.CreatedByUsername = username;
        this.CreatedAtUtc = DateTimeOffset.UtcNow;
    }


}
