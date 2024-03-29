
using BubberDinner.Application.Common.Interface.Errors;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
namespace BubberDinner.Api.Controllers;



public class ErrorsController : ControllerBase
{
    /// <summary>
    ///  It's a ErrorHandling Middleware where it catch an Error Exception and return a Problem Details
    /// </summary>
    /// <returns></returns>
    [Authorize]
    [Route("/error")]
    [HttpGet]
    public IActionResult Error()
    {
        Exception exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>()!.Error;

        return Problem();
    }
}