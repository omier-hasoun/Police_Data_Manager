using Domain.Cases.Witnesses;
using Domain.Citizens;



namespace Domain.Cases.Evidences;

public sealed class Evidence : Entity
{
    public EvidenceType Type { get; private set; } = EvidenceType.Other;
    public string Description { get; private set; } = string.Empty;
    public EvidenceCollectionMethod CollectionMethod { get; private set; } = EvidenceCollectionMethod.CollectedAtScene;
    public Guid CaseId { get; private set; }
    public Case? Case { get; private set; }

    private Evidence() : base()
    {

    }

    private Evidence(EvidenceType type, string description, EvidenceCollectionMethod collectionMethod, Guid caseId, Guid id = default) : base(id)
    {
        this.Type = type;
        this.Description = description;
        this.CaseId = caseId;
        this.CollectionMethod = collectionMethod;
    }

    public static Result<Evidence> Create(EvidenceType type, string description, EvidenceCollectionMethod collectionMethod, Guid caseId, Guid id = default)
    {
        return new Evidence(type, description, collectionMethod, caseId, id);
    }
}
