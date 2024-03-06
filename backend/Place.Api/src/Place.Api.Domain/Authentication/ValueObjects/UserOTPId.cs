namespace Place.Api.Domain.Authentication.ValueObjects;

using System;
using System.Collections.Generic;
using Place.Api.Domain.Common.Abstractions;

/// <summary>
/// Represents a user OTP ID.
/// </summary>
public sealed class UserOTPId : AggregateRootId<Ulid>
{
    /// <summary>
    /// Gets or sets the value of the user OTP ID.
    /// </summary>
    public override Ulid Value { get; protected set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="UserOTPId"/> class.
    /// </summary>
    /// <param name="value">The value of the user OTP ID.</param>
    private UserOTPId(Ulid value)
        => this.Value = value;

    /// <summary>
    /// Creates a new instance of the <see cref="UserOTPId"/> class with a unique value.
    /// </summary>
    /// <returns>An instance of the <see cref="UserOTPId"/> class.</returns>
    public static UserOTPId CreateUnique()
        => new(Ulid.NewUlid());

    /// <summary>
    /// Creates a new instance of the <see cref="UserOTPId"/> class with the specified value.
    /// </summary>
    /// <param name="value">The value of the user OTP ID.</param>
    /// <returns>An instance of the <see cref="UserOTPId"/> class or an error</returns>
    public static UserOTPId Create(Ulid value)
        => new(value);

    /// <inheritdoc/>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }

    private UserOTPId() { }
}