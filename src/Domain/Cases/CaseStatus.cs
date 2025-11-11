namespace Domain.Cases;

public enum CaseStatus
{
    // القضية تم تسجيلها فقط ولم يبدأ التحقيق بعد
    Registered = 1,

    // التحقيق جارٍ من قبل الجهة المختصة
    UnderInvestigation,

    // تم تحويلها إلى النيابة العامة أو المحكمة
    ReferredToProsecution,

    // القضية قيد المحاكمة
    InCourt,

    // تم تعليق القضية مؤقتاً (نقص أدلة، انتظار تقارير، إلخ)
    OnHold,

    // القضية أُغلقت بعد صدور حكم أو انتهاء الإجراءات
    Closed,

}
