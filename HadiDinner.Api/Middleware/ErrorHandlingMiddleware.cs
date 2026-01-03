using System.Net;
using System.Text.Json;

namespace HadiDinner.Api.Middleware;

public class ErrorHandlingMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exc)
        {
            await HandleExceptionAsync(context, exc);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;
        var result = JsonSerializer.Serialize(new { error = "An Error Occurred!" });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (short)code;
        await context.Response.WriteAsync(result);
    }
}
