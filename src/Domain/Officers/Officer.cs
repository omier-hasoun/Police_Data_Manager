

using Domain.Cases;
using Domain.Officers.Departments;
using Domain.States;
using Domain.Users;

namespace Domain.Officers;

public sealed class Officer : AuditableEntity
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
    public ICollection<Case> AssignedCases { get; set; }

    #endregion

    #region Constructors
    private Officer(OfficerBadgeNumber badgeNumber, string firstName, string lastName, Guid departmentId, OfficerRank rank, string email, string phone, Guid inStateId, Guid id = default) : base(id)

    {
        this.Phone = phone;
        this.LastName = lastName;
        this.DepartmentId = departmentId;
        this.FirstName = firstName;
        this.Rank = rank;
        this.Email = email;
        this.InStateId = inStateId;
        this.BadgeNumber = badgeNumber;
    }

    private Officer()
    {

    }
    #endregion

    public static Result<Officer> Create(OfficerBadgeNumber badgeNumber, string firstName, string lastName, Guid departmentId, OfficerRank rank, string email, string phone, Guid inStateId, Guid id = default)
    {


        return new Officer(badgeNumber, firstName, lastName, departmentId, rank, email, phone, inStateId, id);
    }

}
