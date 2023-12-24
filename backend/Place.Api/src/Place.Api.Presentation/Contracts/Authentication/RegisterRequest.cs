namespace Place.Api.Presentation.Contracts.Authentication;

using Destructurama.Attributed;

/// <summary>
/// Represents the request payload for user registration.
/// </summary>
/// <remarks>
/// Use this payload to register a new user by providing the required information.
/// </remarks>
public record RegisterRequest
{
    /// <summary>
    /// Email address of the user.
    /// </summary>
    /// <example>johndoe@gmail.com</example>
    public string Email { get; init; } = null!;

    /// <summary>
    /// Password for the user.
    /// </summary>
    /// <example>OnceUponATime123@</example>
    [NotLogged]
    public string Password { get; init; } = null!;

    /// <summary>
    /// Confirmation password to verify the registration. It should match the main <see cref="Password"/> value.
    /// </summary>
    /// <example>OnceUponATime123@</example>
    public string ConfirmPassword { get; init; } = null!;
}
