
using Domain.Officers;

namespace Domain.Users;

public sealed class User : AuditableEntity
{
    public string Username { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public bool IsActive { get; private set; } = false;
    public TimeSpan? LockTime { get; private set; }
    public Guid OfficerId { get; private set; }
    public bool IsLocked { get; private set; }
    public int FailedLoginAttemptsCount { get; private set; }

    public Officer? OfficerInfo { get; private set; }

    private User()
    { }

    private User(string username, string passwordHash, Guid officerId, Guid id = default) : base(id)
    {
        Username = username;
        PasswordHash = passwordHash;
        OfficerId = officerId;
        IsActive = true;
        IsLocked = false;
        FailedLoginAttemptsCount = 0;
    }

    public void LockAccount(TimeSpan? duration = null)
    {
        IsLocked = true;
        LockTime = duration;
    }

    public void UnlockAccount()
    {
        IsLocked = false;
        LockTime = null;
        FailedLoginAttemptsCount = 0;
    }

    public static Result<User> Create(string username, string passwordHash, Guid officerId, Guid id = default)
    {

        return new User(username, passwordHash, officerId, id);
    }
}
