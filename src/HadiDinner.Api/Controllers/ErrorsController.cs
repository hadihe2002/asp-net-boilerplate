using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace HadiDinner.Api.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features?.Get<IExceptionHandlerFeature>()?.Error;

        Dictionary<string, object?>? extensions = new() { };

        return Problem(title: exception?.Message, extensions: extensions);
    }
}
