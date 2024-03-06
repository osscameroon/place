namespace Place.Api.Presentation.Controllers.Authentication;

using System.Net.Mime;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Place.Api.Application.Authentication.Register;
using Place.Api.Presentation.Contracts.Authentication;
using Place.Api.Presentation.Endpoints;
using Swashbuckle.AspNetCore.Annotations;

public class RegisterController(ISender sender, IMapper mapper) : ApiController
{

    [HttpPost(ApiRoutes.Register.Endpoint)]
    [SwaggerOperation(
        Summary = ApiRoutes.Register.Summary,
        Description = ApiRoutes.Register.Description,
        OperationId = ApiRoutes.Register.OperationId,
        Tags = ["Authentication"]
    )]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [SwaggerResponse(StatusCodes.Status201Created, ApiRoutes.Register.SuccessMessage, typeof(RegisterResponse))]
    public async Task<IActionResult> Register(RegisterRequest request, CancellationToken cancellationToken
    )
    {
        RegisterCommand command = mapper.Map<RegisterCommand>(request);

        ErrorOr<RegisterResult> result = await sender
            .Send(command, cancellationToken)
            .ConfigureAwait(true);

        return result.Match(
            source => this.Created(mapper.Map<RegisterResponse>(source)),
            errors => this.Problem(errors)
        );
    }
}
