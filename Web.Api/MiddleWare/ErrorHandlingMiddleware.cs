using System.Text.Json;
using Domain.CostumExceptions;

namespace Web.Api.MiddleWare;

public class ErrorHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var (statusCode, errorDetails) = exception switch
        {
            GlobalException globalEx => (globalEx.StatusCode, new ErrorDetails
            {
                ErrorType = "Application error",
                Message = globalEx.Message
            }),
            _ => (StatusCodes.Status500InternalServerError, new ErrorDetails
            {
                ErrorType = "Server Error",
                Message = exception.Message
            })
        };

        var response = ResponseModel<object>.ErrorResponse([errorDetails]);

        response.StatusCode = statusCode;
        response.TraceId = context.TraceIdentifier;

        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsJsonAsync(response, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        });
    }
}