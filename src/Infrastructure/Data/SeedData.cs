
using Domain.Cases;
using Domain.Cases.Evidences;
using Domain.Cases.Witnesses;
using Domain.Citizens;
using Domain.Officers;
using Domain.Officers.Departments;
using Domain.States;
using Domain.Users;

namespace Infrastructure.Data;

public static class SeedData
{
    private static Guid OfficerId1 = Guid.Parse("11111111-1111-1111-1111-111111111111");
    private static Guid OfficerId2 = Guid.Parse("22222222-2222-2222-2222-222222222222");
    private static Guid OfficerId3 = Guid.Parse("33333333-3333-3333-3333-333333333333");
    private static Guid OfficerId4 = Guid.Parse("44444444-4444-4444-4444-444444444444");
    private static Guid OfficerId5 = Guid.Parse("55555555-5555-5555-5555-555555555555");

    private static Guid DepartmentId1 = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
    private static Guid DepartmentId2 = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
    private static Guid DepartmentId3 = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");

    private static Guid CitizenId1 = Guid.Parse("Citizen1-0000-0000-0000-000000000000");
    private static Guid CitizenId2 = Guid.Parse("Citizen2-0000-0000-0000-000000000000");
    private static Guid CitizenId3 = Guid.Parse("Citizen3-0000-0000-0000-000000000000");
    private static Guid CitizenId4 = Guid.Parse("Citizen4-0000-0000-0000-000000000000");

    private static Guid CaseId1 = Guid.Parse("Case1111-0000-0000-0000-000000000000");
    private static Guid CaseId2 = Guid.Parse("Case2222-0000-0000-0000-000000000000");
    private static Guid CaseId3 = Guid.Parse("Case3333-0000-0000-0000-000000000000");
    private static Guid CaseId4 = Guid.Parse("Case4444-0000-0000-0000-000000000000");
    private static Guid CaseId5 = Guid.Parse("Case5555-0000-0000-0000-000000000000");

    private static Guid EvidenceId1 = Guid.Parse("Evidence-1000-0000-0000-000000000000");
    private static Guid EvidenceId2 = Guid.Parse("Evidence-2000-0000-0000-000000000000");
    private static Guid EvidenceId3 = Guid.Parse("Evidence-3000-0000-0000-000000000000");
    private static Guid EvidenceId4 = Guid.Parse("Evidence-4000-0000-0000-000000000000");
    private static Guid EvidenceId5 = Guid.Parse("Evidence-5000-0000-0000-000000000000");

    private static Guid CaseParticipantId1 = Guid.Parse("Evidence-1000-0000-0000-000000000000");
    private static Guid CaseParticipantId2 = Guid.Parse("Evidence-2000-0000-0000-000000000000");
    private static Guid CaseParticipantId3 = Guid.Parse("Evidence-3000-0000-0000-000000000000");
    private static Guid CaseParticipantId4 = Guid.Parse("Evidence-4000-0000-0000-000000000000");
    private static Guid CaseParticipantId5 = Guid.Parse("Evidence-5000-0000-0000-000000000000");

    private static Guid UserId1 = Guid.Parse("User1111-0000-0000-0000-000000000000");
    private static Guid UserId2 = Guid.Parse("User2222-0000-0000-0000-000000000000");
    private static Guid UserId3 = Guid.Parse("User3333-0000-0000-0000-000000000000");
    private static Guid UserId4 = Guid.Parse("User4444-0000-0000-0000-000000000000");
    private static Guid UserId5 = Guid.Parse("User5555-0000-0000-0000-000000000000");

    private static Guid WitnessId1 = Guid.Parse("Witness1-0000-0000-0000-000000000000");
    private static Guid WitnessId2 = Guid.Parse("Witness2-0000-0000-0000-000000000000");

    private static Guid StateId1 = Guid.Parse("State111-0000-0000-0000-000000000000");
    private static Guid StateId2 = Guid.Parse("State222-0000-0000-0000-000000000000");

    private static Guid UserLoginAuditId1 = Guid.Parse("Audit111-0000-0000-0000-000000000000");
    private static Guid UserLoginAuditId2 = Guid.Parse("Audit222-0000-0000-0000-000000000000");

    public static List<Officer> LoadOfficers() => new()
    {

    };

    public static List<State> LoadStates() => new()
    {

    };

    public static List<Case> LoadCases() => new()
    {

    };

    public static List<CaseParticipant> LoadCaseParticipants() => new()
    {

    };

    public static List<Citizen> LoadCitizens() => new()
    {

    };

    public static List<Witness> LoadWitnesses() => new()
    {

    };

    public static List<Evidence> LoadEvidences() => new()
    {

    };

    public static List<User> LoadUsers() => new()
    {

    };
    public static List<UserLoginAudit> LoadUserLoginAudits() => new()
    {

    };
    public static List<Department> LoadDepartments() => new()
    {

    };
}
