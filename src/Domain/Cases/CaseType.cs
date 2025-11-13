namespace Domain.Cases;

public enum CaseType
{
    PersonalAssault = 1,

    Homicide,

    PropertyCrime,

    // قضايا المخدرات
    DrugRelated,

    // القضايا المرورية
    TrafficViolation,

    // القضايا الإلكترونية
    CyberCrime,

    // القضايا الأخلاقية أو الجنسية
    MoralCrime,

    // القضايا العامة والنظام
    PublicOrder,

    // القضايا الاقتصادية والمالية
    FinancialCrime,

    // قضايا مفقودين وخطف
    MissingOrKidnapping,

    Theft,
    // قضايا أخرى عامة
    Other,

}
