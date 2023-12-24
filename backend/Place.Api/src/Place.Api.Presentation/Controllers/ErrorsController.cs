namespace Place.Api.Presentation.Controllers;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception = this.HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        return this.Problem();
    }
}
