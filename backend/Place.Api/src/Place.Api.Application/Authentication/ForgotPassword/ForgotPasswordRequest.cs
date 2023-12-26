namespace Place.Api.Application.Authentication.ForgotPassword;

using ErrorOr;
using MediatR;
using Place.Api.Application.Authentication.Register;

/// <summary>
/// Represents a command to request a password change
/// </summary>
public record ForgotPasswordCommand(
    string Email
) : IRequest<ErrorOr<SendOTPResult>>;

/// <summary>
/// Represents a command to validate the new password change
/// </summary>
public record ResetPasswordCommand(
    string Password,
    string ConfirmPassword
) : IRequest<ErrorOr<RegisterResult>>;
