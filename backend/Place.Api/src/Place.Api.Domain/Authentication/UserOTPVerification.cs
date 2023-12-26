
namespace Place.Api.Domain;

using System;
using Place.Api.Domain.Authentication.ValueObjects;
using Place.Api.Domain.Common.Abstractions;

/// <summary>
/// Represents the generated OTP for account recovery
/// </summary>
public sealed class UserOTPVerification : AggregateRoot<UserOTPId, Ulid>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserOTPVerification"/> class.
    /// </summary>
    /// <param name="id">The OTP ID</param>
    /// <param name="userId">The user id.</param>
    /// <param name="otp">The otp, one time password</param>
    internal UserOTPVerification(UserOTPId id, UserId userId, int otp) : base(id)
    {
        this.OTP = otp;
        this.UserId = userId;
    }

    /// <summary>
    /// Gets or sets the userId value
    /// </summary>
    public UserId UserId { get; set; }

    /// <summary>
    /// Gets or sets the otp value
    /// </summary>
    public int OTP { get; private set; }

    /// <summary>
    /// Sets the otp value
    /// </summary>
    /// <param name="otp">OTP value created</param>
    public void SetOTP(int otp) => this.OTP = otp;

    /// <summary>
    /// Gets the date and time when the otp was created.
    /// </summary>
    public DateTime CreatedOnUtc { get; }

    /// <summary>
    /// Gets or sets the date and time when the otp was last modified.
    /// </summary>
    public DateTime? ModifiedOnUtc { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the otp is deleted.
    /// </summary>
    public bool Deleted { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the otp was deleted.
    /// </summary>
    public DateTime? DeletedOnUtc { get; set; }
}
