namespace Place.Api.Domain.Authentication;

using System;
using System.Text;
using Common.Abstractions;
using ErrorOr;
using Services;
using ValueObjects;

/// <summary>
/// Represents a user in the authentication domain.
/// </summary>
public sealed class User : AggregateRoot<UserId, Ulid>, IAuditableEntity, ISoftDeletableEntity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class.
    /// </summary>
    /// <param name="id">The unique identifier for the user.</param>
    /// <param name="userName">The user name.</param>
    /// <param name="email">The email address.</param>
    /// <param name="passwordHash">The hashed password.</param>
    /// <param name="firstName">The first name (optional).</param>
    /// <param name="lastName">The last name (optional).</param>
    internal User(UserId id, UserName userName, Email email, string passwordHash, FirstName? firstName, LastName? lastName)
        : base(id)
    {
        this.UserName = userName;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.PasswordHash = passwordHash;
        this.CreatedOnUtc = DateTime.UtcNow;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class for a new user (without an ID).
    /// </summary>
    /// <param name="userName">The user name.</param>
    /// <param name="email">The email address.</param>
    /// <param name="passwordHash">The hashed password.</param>
    /// <param name="firstName">The first name (optional).</param>
    /// <param name="lastName">The last name (optional).</param>
    internal User(UserName userName, Email email, string passwordHash, FirstName? firstName, LastName? lastName)
    {
        this.UserName = userName;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.PasswordHash = passwordHash;
        this.CreatedOnUtc = DateTime.UtcNow;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class (for ORM or serialization purposes).
    /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private User()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }

    /// <summary>
    /// Gets or sets the user name.
    /// </summary>
    public UserName UserName { get; private set; }

    /// <summary>
    /// Gets or sets the email address.
    /// </summary>
    public Email Email { get; private set; }

    /// <summary>
    /// Gets or sets the first name (optional).
    /// </summary>
    public FirstName? FirstName { get; private set; }

    /// <summary>
    /// Gets or sets the last name (optional).
    /// </summary>
    public LastName? LastName { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether the email is confirmed.
    /// </summary>
    public bool EmailIsConfirmed { get; private set; }

    /// <summary>
    /// Gets or sets the hashed password.
    /// </summary>
    public string PasswordHash { get; private set; }

    /// <summary>
    /// Gets the date and time when the user was created.
    /// </summary>
    public DateTime CreatedOnUtc { get; }

    /// <summary>
    /// Gets or sets the date and time when the user was last modified.
    /// </summary>
    public DateTime? ModifiedOnUtc { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user is deleted.
    /// </summary>
    public bool Deleted { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the user was deleted.
    /// </summary>
    public DateTime? DeletedOnUtc { get; set; }

    /// <summary>
    /// Gets the full name of the user.
    /// </summary>
    public string FullName => GetFullName(this.FirstName, this.LastName);

    /// <summary>
    /// Verifies if the provided password matches the stored password hash.
    /// </summary>
    /// <param name="password">The password to verify.</param>
    /// <param name="passwordHashChecker">The password hash checker service.</param>
    /// <returns>True if the password is verified; otherwise, false.</returns>
    public bool VerifyPasswordHash(string password, IPasswordHashChecker passwordHashChecker)
        => !string.IsNullOrWhiteSpace(password)
           && passwordHashChecker.HashesMatch(this.PasswordHash, password);

    /// <summary>
    /// Changes the user's password.
    /// </summary>
    /// <param name="hash">The new hashed password.</param>
    /// <returns>An error if the password cannot be changed; otherwise, success.</returns>
    public ErrorOr<Success> ChangePassword(string hash)
    {
        if (this.PasswordHash == hash)
        {
            return DomainErrors.User.CannotChangePassword;
        }

        this.PasswordHash = hash;

        return Result.Success;
    }

    /// <summary>
    /// Changes the first name of the user.
    /// </summary>
    /// <param name="firstname">The new first name.</param>
    public void ChangeFirstName(FirstName? firstname)
        => this.FirstName = firstname;

    /// <summary>
    /// Changes the last name of the user.
    /// </summary>
    /// <param name="username">The new last name.</param>
    public void ChangeLastName(LastName? username)
        => this.LastName = username;

    /// <summary>
    /// Changes the user name of the user.
    /// </summary>
    /// <param name="username">The new user name.</param>
    public void ChangeUsername(UserName username)
        => this.UserName = username;

    /// <summary>
    /// Confirms the user's email.
    /// </summary>
    public void ConfirmEmail() =>
        this.EmailIsConfirmed = true;

    /// <summary>
    /// Gets the full name based on the provided first name and last name.
    /// </summary>
    /// <param name="firstName">The first name (optional).</param>
    /// <param name="lastName">The last name (optional).</param>
    /// <returns>The full name of the user.</returns>
    private static string GetFullName(FirstName? firstName, LastName? lastName)
    {
        StringBuilder builder = new();
        builder.Append(firstName)
            .Append(' ')
            .Append(lastName);

        return builder.ToString().Trim();
    }

    public static implicit operator User(void v) => throw new NotImplementedException();
}
