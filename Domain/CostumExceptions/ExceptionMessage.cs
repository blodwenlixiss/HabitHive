namespace Domain.CostumExceptions;

public static class ExceptionMessage
{
    public static readonly Func<string, string> UserAlreadyExists =
        email => $"მომხმარებელი ელფოსტით ({email}) უკვე არსებობს";

    public static readonly Func<string, string> UserNotFound =
        email => $"მომხმარებელი ელფოსტით ({email}) ვერ მოიძებნა";

    public static readonly string InvalidPassword = "პაროლი არასწორია";
    public static readonly string UnauthorizedAccess = "უკანონო წვდომა";

    public static readonly Func<Guid?, string> HobbyNotFound =
        hobbyId => $"ჰობი - ({hobbyId}) ვერ მოიძებნა";

    public static readonly string HobbyTitleIsRequired = "ჰობის სათაური აუცილებელია";

    public static readonly Func<Guid?, string> HobbyAlreadyCompletedToday =
        hobbyId => $"ჰობი - ({hobbyId}) უკვე შესრულებულია დღეს";

    public static readonly string HobbyInactive = "ჰობი ამჟამად არაქტიურია";

    public static readonly Func<Guid?, string> TaskNotFound =
        taskId => $"დავალება - ({taskId}) ვერ მოიძებნა";

    public static readonly string TaskTitleIsRequired = "დავალების სათაური აუცილებელია";
    public static readonly string TaskDueTimeInvalid = "დავალების დასრულების დრო არასწორია";

    public static readonly Func<Guid?, string> CompletionNotFound =
        completionId => $"ჰობის დასრულება - ({completionId}) ვერ მოიძებნა";

    public static readonly Func<Guid?, string> CompletionAlreadyExists =
        completionId => $"ჰობის დასრულება - ({completionId}) უკვე რეგისტრირებულია დღეს";
}