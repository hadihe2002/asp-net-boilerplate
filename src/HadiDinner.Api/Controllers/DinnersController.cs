using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HadiDinner.Api.Controllers;

[Route("[controller]")]
public class DinnersController : ApiController
{
    [HttpGet]
    [Authorize(Roles = "Role")]
    public IActionResult ListDinners()
    {
        return Ok(Array.Empty<string>());
    }
}
