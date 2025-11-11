
namespace Domain.Users;

public sealed class UserLoginAudit : Entity
{
    public Guid UserId { get; private set; }
    public DateTimeOffset LoginTime { get; private set; }
    public bool IsSuccessful { get; private set; }
    public string Username { get; private set; } = string.Empty;
    public string IPAddress { get; private set; } = string.Empty;
    public string DeviceInfo { get; private set; } = string.Empty;
    public string? FailureReason { get; private set; }

    public User? UserInfo { get; private set; }

    private UserLoginAudit()
    {

    }

    private UserLoginAudit(Guid userId, string username, bool isSuccessful, string ipAddress, string deviceInfo, string? failureReason = null, Guid id = default) : base(id)
    {

        this.UserId = userId;
        this.Username = username;
        this.IsSuccessful = isSuccessful;
        this.IPAddress = ipAddress;
        this.DeviceInfo = deviceInfo;
        this.FailureReason = failureReason;
        this.LoginTime = DateTimeOffset.UtcNow;
    }

    public static UserLoginAudit Create(Guid userId, string username, bool isSuccessful, string ipAddress, string deviceInfo, string? failureReason = null, Guid id = default)
    {


        return new UserLoginAudit(userId, username, isSuccessful, ipAddress, deviceInfo, failureReason, id);
    }
}
