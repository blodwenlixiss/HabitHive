using System.Text.Json.Serialization;

namespace Domain.CostumExceptions;

public class ErrorDetails
{
    public string? ErrorType { get; set; }

    public string Message { get; set; }
}