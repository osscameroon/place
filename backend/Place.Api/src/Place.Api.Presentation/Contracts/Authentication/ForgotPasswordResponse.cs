namespace Place.Api.Presentation.Contrats.Authentication;

public sealed record SentOTPResponse
(
    bool OtpSent
);

public sealed record VerifyOTPResponse
(
    bool OtpValid
);

public sealed record ResetPasswordResponse
(
    string Id,
    string Login,
    string Username,
    bool EmailIsConfirmed
);
