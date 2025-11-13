namespace Domain.Common.Abstractions;

public abstract class SoftDeletableEntity : Entity
{
    public DateTimeOffset? DeletedAtUtc => _deletedAtUtc;
    public bool IsDeleted => _isDeleted;
    public string? DeletedByUsername => _deletedByUsername;


    private bool _isDeleted = false;
    private DateTimeOffset? _deletedAtUtc = null;
    private string? _deletedByUsername = null;

    private SoftDeletableEntity()
    {

    }

    protected SoftDeletableEntity(Guid id = default) : base(id)
    {

    }

    public void Delete(string? username)
    {
        _isDeleted = true;
        _deletedAtUtc = DateTimeOffset.UtcNow;
        _deletedByUsername = username;
    }

    public void UndoDelete()
    {
        _isDeleted = false;
        _deletedAtUtc = null;
        _deletedByUsername = null;
    }


}
