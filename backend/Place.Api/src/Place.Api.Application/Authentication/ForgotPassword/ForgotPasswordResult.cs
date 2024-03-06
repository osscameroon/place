namespace Place.Api.Application;

using Domain.Authentication;

public record SendOTPResult
{

    /// <summary>
    /// Gets or sets if the otp was sent.
    /// </summary>    
    public bool OTPSent { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SendOTPResult"/> class based on user entity and generated otp for account recovery
    /// </summary>
    /// <param name="otpSent">If the otp was successfully sent</param>
    public SendOTPResult(bool otpSent) => this.OTPSent = otpSent;
}

public record VerifyOTPResult
{
    /// <summary>
    /// Gets or sets the validity of the otp.
    /// </summary>
    public bool OTPValid { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="VerifyOTPResult"/> class based on user entity and generated otp for account recovery
    /// </summary>
    /// <param name="otpValid">If the otp provided by the user is valid.</param>
    public VerifyOTPResult(bool otpValid) => this.OTPValid = otpValid;
}

public record ResetPasswordResult
{
    /// <summary>
    /// Gets the login name associated with the registered user.
    /// </summary>
    public string Login { get; } = null!;

    /// <summary>
    /// Gets the username associated with the registered user.
    /// </summary>
    public string Username { get; } = null!;

    /// <summary>
    /// Gets or sets the unique identifier of the registered user.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ResetPasswordResult"/> class based on user entity and generated otp for account recovery
    /// </summary>
    /// <param name="user">The user account already existing in DB</param>
    public ResetPasswordResult(User user)
    {
        this.Id = user.Id.Value.ToString();
        this.Login = user.Email.Value;
        this.Username = user.UserName.Value;
    }
}
