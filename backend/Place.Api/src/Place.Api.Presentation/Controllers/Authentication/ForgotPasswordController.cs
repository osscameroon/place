namespace Place.Api.Presentation.Controllers.Authentication;

using System.Net.Mime;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Place.Api.Application;
using Place.Api.Application.Authentication.ForgotPassword;
using Place.Api.Presentation.Contrats.Authentication;
using Place.Api.Presentation.Endpoints;
using Swashbuckle.AspNetCore.Annotations;

public class ForgotPasswordController(ISender sender, IMapper mapper) : ApiController
{
    [HttpPost(ApiRoutes.ForgotPassword.Endpoint)]
    [SwaggerOperation(
        Summary = ApiRoutes.ForgotPassword.Summary,
        Description = ApiRoutes.ForgotPassword.Description,
        OperationId = ApiRoutes.ForgotPassword.OperationId,
        Tags = ["Authentication"]
    )]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [SwaggerResponse(StatusCodes.Status200OK, ApiRoutes.ForgotPassword.SuccessMessage, typeof(SentOTPResponse))]
    public async Task<IActionResult> ForgotPassword(SendOTPRequest request, CancellationToken cancellationToken
    )
    {
        ForgotPasswordCommand command = mapper.Map<ForgotPasswordCommand>(request);

        ErrorOr<SendOTPResult> result = await sender
            .Send(command, cancellationToken)
            .ConfigureAwait(true);

        return result.Match(
            source => this.Ok(mapper.Map<SentOTPResponse>(source)),
            errors => this.Problem(errors)
        );
    }
}
