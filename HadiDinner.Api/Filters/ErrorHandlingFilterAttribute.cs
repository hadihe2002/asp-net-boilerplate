using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HadiDinner.Api.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        var errorResult = new ProblemDetails()
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Title = "Here is an error",
            Status = (int)HttpStatusCode.InternalServerError
        };

        context.Result = new ObjectResult(errorResult);

        context.ExceptionHandled = true;
    }
}
