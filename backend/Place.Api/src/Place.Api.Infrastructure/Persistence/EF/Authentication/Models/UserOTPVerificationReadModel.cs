namespace Place.Api.Infrastructure;

using System;
using Place.Api.Domain.Common.Abstractions;

public sealed class UserOTPVerificationReadModel : IAuditableEntity, ISoftDeletableEntity
{
    /// <summary>
    /// Gets or sets the unique identifier for the user otp.
    /// </summary>
    public Ulid Id { get; set; }

    /// <summary>
    /// Gets or sets the user ID.
    /// </summary>
    public Ulid UserId { get; set; }

    /// <summary>
    /// Gets or sets the otp value
    /// </summary>
    public int OTP { get; set; }

    /// <summary>
    /// Gets or sets the UTC date and time when the user was created.
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }

    /// <summary>
    /// Gets or sets the UTC date and time when the user was last modified.
    /// </summary>
    public DateTime? ModifiedOnUtc { get; set; }

    /// <summary>
    /// Gets or sets the UTC date and time when the user was deleted.
    /// </summary>
    public DateTime? DeletedOnUtc { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user is deleted.
    /// </summary>
    public bool Deleted { get; set; }
}
