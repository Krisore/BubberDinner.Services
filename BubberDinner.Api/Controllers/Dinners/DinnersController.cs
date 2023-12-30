using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.Api.Controllers.Dinners;
[Route("[controller]")]
public class DinnersController : ApiBaseController
{
    [HttpGet]
    [Authorize]
    public IActionResult ListOfDinners()
    {
        return Ok(Array.Empty<string>());
    }
}