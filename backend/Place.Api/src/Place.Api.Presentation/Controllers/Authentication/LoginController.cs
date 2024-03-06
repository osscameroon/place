namespace Place.Api.Presentation.Controllers.Authentication;

using System.Net.Mime;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Place.Api.Application.Authentication.Login;
using Place.Api.Presentation.Contracts.Authentication;
using Place.Api.Presentation.Endpoints;
using Swashbuckle.AspNetCore.Annotations;

public class LoginController(ISender sender, IMapper mapper) : ApiController
{
    [HttpPost(ApiRoutes.Login.Endpoint)]
    [SwaggerOperation(
        Summary = ApiRoutes.Login.Summary,
        Description = ApiRoutes.Login.Description,
        OperationId = ApiRoutes.Login.OperationId,
        Tags = ["Authentication"]
    )]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [SwaggerResponse(StatusCodes.Status200OK, ApiRoutes.Login.SuccessMessage, typeof(LoginResponse))]
    public async Task<IActionResult> Login(LoginRequest request, CancellationToken cancellationToken
    )
    {
        LoginQuery query = mapper.Map<LoginQuery>(request);

        ErrorOr<LoginResult> result = await sender
            .Send(query, cancellationToken)
            .ConfigureAwait(true);

        return result.Match(
            source => this.Ok(mapper.Map<LoginResponse>(source)),
            errors => this.Problem(errors)
        );
    }
}
