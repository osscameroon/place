namespace Place.Api.Application.Common.Interfaces.Authentication;

using Place.Api.Domain.Authentication.ValueObjects;

/// <summary>
/// Represents the password hasher interface.
/// </summary>
public interface IPasswordHasher
{
    /// <summary>
    /// Hashes the specified password.
    /// </summary>
    /// <param name="password">The password to be hashed.</param>
    /// <returns>The password hash.</returns>
    string HashPassword(Password password);
}
