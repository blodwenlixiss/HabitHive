using Domain.CostumExceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.Api.MiddleWare;

public class ValidationModelFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errorDetails = context.ModelState
                .Where(x => x.Value?.Errors.Count > 0)
                .SelectMany(x => x.Value!.Errors.Select(e => new ErrorDetails
                {
                    ErrorType = "Bad Request Error",
                    Field = x.Key,
                    Message = e.ErrorMessage
                }))
                .ToList();
            var result = new ResponseModel<object>
            {
                StatusCode = 400,
                Success = false,
                Errors = errorDetails,
                TraceId = context.HttpContext.TraceIdentifier,
                Timestamp = DateTime.UtcNow
            };

            context.Result = new BadRequestObjectResult(result);
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}