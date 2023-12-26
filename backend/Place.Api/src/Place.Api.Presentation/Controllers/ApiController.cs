namespace Place.Api.Presentation.Controllers;

using ErrorOr;
using Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

[ApiController]
[Route("api")]
public class ApiController : ControllerBase
{
#pragma warning disable CA1002
    protected IActionResult Problem(List<Error> errors)
#pragma warning restore CA1002
    {
        if (errors.Count is 0)
        {
            return this.Problem();
        }

        if (errors.All(error => error.Type == ErrorType.Validation))
        {
            return this.ValidationProblem(errors);
        }

        this.HttpContext.Items[HttpContextItemKeys.Errors] = errors;

        return this.Problem(errors[0]);
    }

#pragma warning disable CA1859
    private IActionResult Problem(Error error)
#pragma warning restore CA1859
    {
        int statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        return this.Problem(statusCode: statusCode, title: error.Description);
    }

    private ActionResult ValidationProblem(List<Error> errors)
    {
        ModelStateDictionary modelStateDictionary = new ModelStateDictionary();

        foreach (Error error in errors)
        {
            modelStateDictionary.AddModelError(
                error.Code,
                error.Description);
        }

        return this.ValidationProblem(modelStateDictionary);
    }


    protected IActionResult Created(object objectResult)
        => new ObjectResult(objectResult) { StatusCode = StatusCodes.Status201Created };
}
