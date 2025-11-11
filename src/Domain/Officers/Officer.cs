

using Domain.Officers.Departments;
using Domain.States;
using Domain.Users;

namespace Domain.Officers;

public sealed class Officer : Entity
{
    #region Properties
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string FullName
    {
        get
        {
            return FirstName + " " + LastName;
        }
    }
    public Guid DepartmentId { get; private set; }
    public string Phone { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public Guid InStateId { get; private set; }
    public OfficerRank Rank { get; private set; } = OfficerRank.Constable;
    public OfficerBadgeNumber BadgeNumber { get; private set; } = default!;

    public User? UserInfo { get; private set; }
    public State? InState { get; private set; }
    public Department? Department { get; private set; }
    #endregion

    #region Constructors
    private Officer(string firstName, string lastName, Guid departmentId, OfficerRank rank, string email, string phone, Guid inStateId, Guid id = default) : base(id)

    {
        this.Phone = phone;
        this.LastName = lastName;
        this.DepartmentId = departmentId;
        this.FirstName = firstName;
        this.Rank = rank;
        this.Email = email;
        this.InStateId = inStateId;
    }

    private Officer()
    {

    }
    #endregion

    #region Factory Methods
    public static Result<Officer> Create(string firstName, string lastName, Guid departmentId, OfficerRank rank, string email, string phone, Guid inStateId, Guid id = default)
    {


        return new Officer(firstName, lastName, departmentId, rank, email, phone, inStateId, id);
    }

    public Result<Created> AssignBadgeNumber(string value)
    {
        try
        {
            var badge = new OfficerBadgeNumber(value);
            this.BadgeNumber = badge;
        }
        catch
        {
            return Error.Validation("Invalid badge number provided.");
        }

        return Result.Created;
    }
    #endregion
}
