using System.Text.Json.Serialization;

namespace Domain.CostumExceptions;

public class ResponseModel<T>
{
    public int StatusCode { get; set; }
    public bool Success { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public T? Data { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<ErrorDetails>? Errors { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string TraceId { get; set; }

    public DateTime Timestamp { get; set; }


    public static ResponseModel<T> SuccessMessage(T? data = default, int statusCode = 200)
    {
        return new ResponseModel<T>
        {
            StatusCode = statusCode,
            Success = true,
            Data = data,
            Timestamp = DateTime.UtcNow
        };
    }

    public static ResponseModel<T> ErrorResponse(List<ErrorDetails> errorDetails)
    {
        return new ResponseModel<T>
        {
            Success = false,
            Errors = errorDetails,
            Timestamp = DateTime.UtcNow
        };
    }
}