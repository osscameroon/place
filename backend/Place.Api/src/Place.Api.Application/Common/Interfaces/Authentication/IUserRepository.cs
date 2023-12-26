namespace Place.Api.Application.Common.Interfaces.Authentication;

using System.Threading.Tasks;
using Application.Authentication.Login;
using Domain.Authentication;
using Domain.Authentication.ValueObjects;

/// <summary>
/// Represents a repository for managing user-related data.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Checks if the specified email is unique in the repository.
    /// </summary>
    /// <param name="email">The email address to check for uniqueness.</param>
    /// <returns>True if the email is unique; otherwise, false.</returns>
    Task<bool> IsUniqueEmail(Email email);

    /// <summary>
    /// Adds a new user to the repository.
    /// </summary>
    /// <param name="user">The user to add to the repository.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task AddAsync(User user);

    /// <summary>
    /// Get user by email.
    /// </summary>
    /// <param name="email"></param>
    /// <returns><see cref="User"/> or null</returns>
    Task<User?> GetByEmail(string email);

}
