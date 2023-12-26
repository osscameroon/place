namespace Place.Api.Presentation.Contrats.Authentication;

/// <summary>
/// Represents the request payload to send recovery otp.
/// </summary>
/// <remarks>
/// Use this payload generates an otp sent by mail to the user for account recovery.
/// </remarks>
public record SendOTPRequest
{
    /// <summary>
    /// Email address of the user.
    /// </summary>
    /// <example>johndoe@gmail.com</example>
    public string Email { get; init; } = null!;

}

/// <summary>
/// Represents the request payload to verify versus the otp sent by mail and stored in database.
/// </summary>
/// <remarks>
/// Use this payload to verify it is the actual user changing the password.
/// </remarks>
public record VerifyOTPRequest
{
    /// <summary>
    /// OTP sent by mail.
    /// </summary>
    /// <example>johndoe@gmail.com</example>
    public string OTP { get; init; } = null!;

}

/// <summary>
/// Represents the request payload to change user password.
/// </summary>
/// <remarks>
/// Use this payload change the password of the user.
/// </remarks>
public record ResetPasswordRequest
{
    /// <summary>
    /// New password for the user.
    /// </summary>
    /// <example>OnceUponATime123@</example>
    public string Password { get; init; } = null!;

    /// <summary>
    /// Confirmation password to recover account. It should match the main <see cref="Password"/> value.
    /// </summary>
    /// <example>OnceUponATime123@</example>
    public string ConfirmPassword { get; init; } = null!;
}
