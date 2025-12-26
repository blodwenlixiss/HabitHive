namespace Domain.CostumExceptions;

public class GlobalException : Exception
{
    public readonly int StatusCode;

    public GlobalException(string message, int statusCode) : base(message)
    {
        StatusCode = statusCode;
    }

    public GlobalException(string message) : base(message)
    {
        
    }
}