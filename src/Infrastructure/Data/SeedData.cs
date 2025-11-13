
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
    private static Guid CitizenId5 = Guid.Parse("Citizen5-0000-0000-0000-000000000000");
    private static Guid CitizenId6 = Guid.Parse("Citizen6-0000-0000-0000-000000000000");
    private static Guid CitizenId7 = Guid.Parse("Citizen7-0000-0000-0000-000000000000");
    private static Guid CitizenId8 = Guid.Parse("Citizen8-0000-0000-0000-000000000000");
    private static Guid CitizenId9 = Guid.Parse("Citizen9-0000-0000-0000-000000000000");

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
    private static Guid CaseParticipantId6 = Guid.Parse("Evidence-6000-0000-0000-000000000000");
    private static Guid CaseParticipantId7 = Guid.Parse("Evidence-7000-0000-0000-000000000000");
    private static Guid CaseParticipantId8 = Guid.Parse("Evidence-8000-0000-0000-000000000000");
    private static Guid CaseParticipantId9 = Guid.Parse("Evidence-9000-0000-0000-000000000000");

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
        Officer.Create("John", "Doe", DepartmentId1, OfficerRank.Constable,"John@gmail.com", "017685647893", StateId1, OfficerId1).Value,
        Officer.Create("Peter", "Parker", DepartmentId1, OfficerRank.Constable,"Peter@gmail.com", "013685647893", StateId1, OfficerId2).Value,
        Officer.Create("walter", "White", DepartmentId1, OfficerRank.Sergeant,"walter@gmail.com", "01235647893", StateId2, OfficerId3).Value,
        Officer.Create("Luffy", "Monkey", DepartmentId1, OfficerRank.Detective,"Luffy@gmail.com", "015685647893", StateId2, OfficerId4).Value,
        Officer.Create("Mohammed", "Abo-Hadhoud", DepartmentId1, OfficerRank.Chief,"Mohammed@gmail.com", "01333647893", StateId1, OfficerId5).Value,

    };

    public static List<State> LoadStates() => new()
    {
        State.Create("Berlin", "BER", StateId1).Value,
        State.Create("Hamburg", "HAM", StateId2).Value,
    };

    public static List<Case> LoadCases() => new()
    {
        Case.Create(CaseType.DrugRelated, "Drug found near the bahnhof", "some shity description", DateTimeOffset.UtcNow, CaseId1).Value,
        Case.Create(CaseType.Theft, "Stolen bike", "some shity description", DateTimeOffset.UtcNow, CaseId2).Value,
        Case.Create(CaseType.PersonalAssault, "Assault in the park", "some shity description", DateTimeOffset.UtcNow, CaseId3).Value,
        Case.Create(CaseType.FinancialCrime, "Credit card fraud", "some shity description", DateTimeOffset.UtcNow, CaseId4).Value,
        Case.Create(CaseType.PersonalAssault, "Personal Assualt in banhof", "some shity description", DateTimeOffset.UtcNow, CaseId5).Value,

    };

    public static List<CaseParticipant> LoadCaseParticipants() => new()
    {
        CaseParticipant.Create(CaseId1, CitizenId1, CaseParticipantRole.Victim, CaseParticipantId1).Value,
        CaseParticipant.Create(CaseId1, CitizenId2, CaseParticipantRole.Suspect, CaseParticipantId2).Value,
        CaseParticipant.Create(CaseId2, CitizenId3, CaseParticipantRole.Victim, CaseParticipantId3).Value,
        CaseParticipant.Create(CaseId3, CitizenId4, CaseParticipantRole.Victim, CaseParticipantId4).Value,
        CaseParticipant.Create(CaseId3, CitizenId5, CaseParticipantRole.Suspect, CaseParticipantId5).Value,
        CaseParticipant.Create(CaseId4, CitizenId6, CaseParticipantRole.Victim, CaseParticipantId6).Value,
        CaseParticipant.Create(CaseId4, CitizenId7, CaseParticipantRole.Perpetrator, CaseParticipantId7).Value,
        CaseParticipant.Create(CaseId5, CitizenId8, CaseParticipantRole.Victim, CaseParticipantId8).Value,
        CaseParticipant.Create(CaseId5, CitizenId9, CaseParticipantRole.Accused, CaseParticipantId9).Value,

    };

    public static List<Citizen> LoadCitizens() => new()
    {

        Citizen.Create("Alice", "Smith", new CitizenNationalId("12345678901"),"Hanostr 33, 34323 Hamburg", DateTime.Today.AddYears(-16), CitizenId1).Value,
        Citizen.Create("Bob", "Johnson", new CitizenNationalId("23456789012"),"Musterstr 12, 10115 Berlin", DateTime.Today.AddYears(-25), CitizenId2).Value,
        Citizen.Create("Charlie", "Brown", new CitizenNationalId("34567890123"),"Beispielweg 5, 50667 Köln", DateTime.Today.AddYears(-30), CitizenId3).Value,
        Citizen.Create("David", "Williams", new CitizenNationalId("45678901234"),"Hauptstr 20, 80331 München", DateTime.Today.AddYears(-22), CitizenId4).Value,
        Citizen.Create("Eva", "Davis", new CitizenNationalId("56789012345"),"Schulstr 8, 20095 Hamburg", DateTime.Today.AddYears(-28), CitizenId5).Value,
        Citizen.Create("Frank", "Miller", new CitizenNationalId("67890123456"),"Parkweg 15, 28195 Bremen", DateTime.Today.AddYears(-35), CitizenId6).Value,
        Citizen.Create("Grace", "Wilson", new CitizenNationalId("78901234567"),"Gartenstr 3, 44135 Dortmund", DateTime.Today.AddYears(-19), CitizenId7).Value,
        Citizen.Create("Hannah", "Moore", new CitizenNationalId("89012345678"),"Ringstr 10, 99084 Erfurt", DateTime.Today.AddYears(-27), CitizenId8).Value,
        Citizen.Create("Ian", "Taylor", new CitizenNationalId("90123456789"), "Allee 7, 01067 Dresden", DateTime.Today.AddYears(-31), CitizenId9).Value,

    };

    public static List<Witness> LoadWitnesses() => new()
    {
        Witness.Create("Saw a suspicious person near the scene",CitizenId1, CaseId1, WitnessId1).Value,
        Witness.Create("Heard loud noises around midnight", CitizenId2, CaseId2, WitnessId2).Value,

    };

    public static List<Evidence> LoadEvidences() => new()
    {
        Evidence.Create(EvidenceType.Physical, "Knife with fingerprints", EvidenceCollectionMethod.CollectedAtScene, CaseId1, EvidenceId1).Value,
        Evidence.Create(EvidenceType.Digital, "CCTV footage", EvidenceCollectionMethod.CollectedAtScene, CaseId2, EvidenceId2).Value,
        Evidence.Create(EvidenceType.Other, "Bank statements", EvidenceCollectionMethod.RetrievedFromDatabase, CaseId3, EvidenceId3).Value,
        Evidence.Create(EvidenceType.Physical, "Drug samples", EvidenceCollectionMethod.CollectedAtScene, CaseId3, EvidenceId4).Value,
        Evidence.Create(EvidenceType.Digital, "Email correspondence", EvidenceCollectionMethod.RetrievedFromDatabase, CaseId4, EvidenceId5).Value,
    };

    public static List<User> LoadUsers()
    {

        return
        [
            User.Create("Omier32", , , UserId1).Value,
        ];
    }
    public static List<UserLoginLog> LoadUserLoginAudits() => new()
    {

    };
    public static List<Department> LoadDepartments() => new()
    {

    };
}
