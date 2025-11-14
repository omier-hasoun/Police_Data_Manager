using System.Collections;
using Domain.Cases.Evidences;
using Domain.Cases.Witnesses;
using Domain.Officers;

namespace Domain.Cases;

public sealed class Case : AuditableEntity
{
    #region Properties
    public CaseType Type { get; private set; } = CaseType.Other;
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string? ProgressReport { get; private set; }
    public string? FinalReport { get; private set; }
    public CaseStatus Status { get; private set; } = CaseStatus.Registered;
    public DateTimeOffset? IncidentDate { get; private set; } = null;
    public DateTimeOffset? InvestigationStartedAt { get; private set; } = null;
    public DateTimeOffset? ClosedAt { get; private set; } = null;

    public ICollection<Officer> AssignedOfficers { get; private set; } = [];
    public ICollection<Evidence> Evidences { get; private set; } = [];
    public ICollection<CaseParticipant> Participants { get; private set; } = [];
    public ICollection<CaseParticipant> Accuseds
    {
        get
        {
            return Participants.Where(p => p.Role == CaseParticipantRole.Accused).ToList();
        }
    }
    public ICollection<CaseParticipant> Perpetrators
    {
        get
        {
            return Participants.Where(p => p.Role == CaseParticipantRole.Perpetrator).ToList();
        }
    }
    public ICollection<CaseParticipant> Suspects
    {
        get
        {

            return Participants.Where(p => p.Role == CaseParticipantRole.Suspect).ToList();
        }
    }
    public ICollection<CaseParticipant> Victims
    {
        get
        {
            return Participants.Where(p => p.Role == CaseParticipantRole.Victim).ToList();
        }
    }
    public ICollection<Witness> Witnesses { get; private set; } = [];
    #endregion

    #region Constructors
    private Case()
    {

    }

    private Case(CaseType type, string title, string description, CaseStatus status, DateTimeOffset? incidentDate, Guid id = default) : base(id)
    {
        this.Type = type;
        this.Title = title;
        this.Description = description;
        this.Status = status;
        this.IncidentDate = incidentDate;
        this.ProgressReport = null;
        this.InvestigationStartedAt = null;
        this.FinalReport = null;
    }
    #endregion

    #region Factory Methods
    public static Result<Case> Create(CaseType type, string title, string description, DateTimeOffset? incidentDate = null, Guid id = default)
    {
        return new Case(type, title, description, CaseStatus.Registered, incidentDate, id);
    }
    #endregion


    public Result<Updated> Close(string finalReport)
    {
        if (string.IsNullOrEmpty(this.ProgressReport))
        {
            return Error.Forbidden("dsfdf", "you must write a report before closing the case");
        }

        this.FinalReport = finalReport;
        this.Status = CaseStatus.Closed;
        this.ClosedAt = DateTimeOffset.UtcNow;
        return Result.Updated;
    }

}
