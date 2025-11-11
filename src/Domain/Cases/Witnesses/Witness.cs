using Domain.Citizens;

namespace Domain.Cases.Witnesses;

public sealed class Witness : Entity
{
    public string Statements { get; private set; } = string.Empty;
    public Guid CitizenId { get; private set; }
    public Guid CaseId { get; private set; }

    public Citizen? CitizenInfo { get; private set; }
    public Case? WitnessedForCase { get; private set; }

    private Witness()
    {

    }

    private Witness(string statemnets, Guid citizenId, Guid caseId, Guid id = default) : base(id)
    {
        Statements = statemnets;
        CitizenId = citizenId;
        CaseId = caseId;
    }

    public static Result<Witness> Create(string statemnets, Guid citizenId, Guid caseId, Guid id = default)
    {

        return new Witness(statemnets, citizenId, caseId, id);
    }
}
