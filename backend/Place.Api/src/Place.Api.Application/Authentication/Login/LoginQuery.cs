namespace Place.Api.Application.Authentication.Login;

using Destructurama.Attributed;
using ErrorOr;
using MediatR;

public class LoginQuery : IRequest<ErrorOr<LoginResult>>

{
    public string Email { get; init; } = null!;

    [NotLogged]
    public string Password { get; init; } = null!;
}
