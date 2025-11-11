
using Domain.Citizens;

namespace Domain.Cases;

public sealed class CaseParticipant : Entity
{

    public Guid CaseId { get; private set; }
    public Guid CitizenId { get; private set; }
    public CaseParticipantRole Role { get; private set; } = CaseParticipantRole.Perpetrator;

    public Case? Case { get; private set; }
    public Citizen? CitizenInfo { get; private set; }


    private CaseParticipant()
    {

    }

    private CaseParticipant(Guid caseId, Guid citizenId, CaseParticipantRole role, Guid id = default) : base(id)
    {
        this.Role = role;
        this.CaseId = caseId;
        this.CitizenId = citizenId;
    }

    public static Result<CaseParticipant> Create(Guid caseId, Guid citizenId, CaseParticipantRole role, Guid id = default)
    {


        return new CaseParticipant(caseId, citizenId, role, id);
    }
}
