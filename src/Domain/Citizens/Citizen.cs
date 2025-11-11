
namespace Domain.Citizens;

public sealed class Citizen : Entity
{
    #region Properties
    public string FullName
    {
        get { return $"{FirstName} {LastName}"; }
    }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public CitizenNationalId NationalId { get; private set; } = default!;
    public DateTime DateOfBirth { get; private set; } = default;
    public string FullAddress { get; private set; } = string.Empty;
    public string? Phone { get; private set; }
    public bool IsAlive { get; private set; }
    #endregion

    #region Constructors
    private Citizen()
    {

    }
    private Citizen(string firstName, string lastName, CitizenNationalId nationalId, string fullAddress, DateTime dateOfBirth, string? phone = default, Guid id = default) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        NationalId = nationalId;
        Phone = phone;
        FullAddress = fullAddress;
        DateOfBirth = dateOfBirth;
        IsAlive = true;
    }
    #endregion

    #region Factory Methods
    public static Result<Citizen> Create(string firstName, string lastName, CitizenNationalId nationalId, string fullAddress, DateTime dateOfBirth, string? phone, Guid id = default)
    {
        return new Citizen(firstName, lastName, nationalId, fullAddress, dateOfBirth, phone, id);
    }
    public static Result<Citizen> Create(string firstName, string lastName, CitizenNationalId nationalId, string fullAddress, DateTime dateOfBirth, Guid id = default)
    {
        return Create(firstName, lastName, nationalId, fullAddress, dateOfBirth, null, id);
    }
    #endregion

    public void MarkDeceased()
    {
        this.IsAlive = false;
    }
}
