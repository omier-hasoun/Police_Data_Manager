
using Domain.Officers;
using Microsoft.AspNetCore.Identity;

namespace Domain.Users;

public sealed class User : AuditableEntity
{
    #region Main Properties

    public string Username { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public bool IsActive { get; private set; } = true;
    public DateTimeOffset? LockedUntil { get; private set; }
    public DateTimeOffset? LockStartTime { get; private set; }
    public Guid OfficerId { get; private set; }
    public bool IsLocked { get; private set; }
    public int FailedLoginAttemptsCount { get; private set; }
    public List<string> Permissions { get; set; }
    public List<string> Roles { get; set; }

    #endregion

    #region Navigation Properties
    public Officer? OfficerInfo { get; private set; }

    #endregion

    #region Constants

    private static readonly TimeSpan DefaultLockDuration = TimeSpan.FromMinutes(15);

    #endregion

    #region Constructors
    private User()
    { }

    private User(string username, string passwordHash, Guid officerId, Guid id = default) : base(id)
    {
        Username = username;
        PasswordHash = passwordHash;
        OfficerId = officerId;
        IsActive = true;
    }
    #endregion

    public static Result<User> Create(string username, string passwordPlainText, Guid officerId, Guid id = default)
    {
        var user = new User(username, string.Empty, officerId, id);

        return user;
    }


    public void IncrementFailedLoginAttempts()
    {
        FailedLoginAttemptsCount++;
    }

    public void LockAccount(TimeSpan? duration = null)
    {
        IsLocked = true;
        LockStartTime = DateTime.UtcNow;
        LockedUntil = LockStartTime.Value.Add(duration ?? DefaultLockDuration);
    }

    public void UnlockAccount()
    {
        IsLocked = false;
        LockedUntil = null;
        LockStartTime = null;
        FailedLoginAttemptsCount = 0;
    }

}
