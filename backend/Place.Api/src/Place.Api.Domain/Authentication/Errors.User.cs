namespace Place.Api.Domain.Authentication;

using ErrorOr;

public static class DomainErrors
{
#pragma warning disable CA1034

    public static class User
    {
        public static Error CannotChangePassword => Error.Validation(
            "User.CannotChangePassword",
            "The password cannot be changed to the specified password.");

        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuplicateEmail",
            description: "Email is already in use.");

        public static Error NotFoundEmail => Error.Conflict(
            code: "User.NotFoundEmail",
            description: "Email not found.");
    }

    public static class Email
    {
        public static Error NullOrEmpty => Error.Validation(
            code: "Email.NullOrEmpty",
            description: "The email is required.");

        public static Error LongerThanAllowed => Error.Validation(
            code: "Email.LongerThanAllowed",
            description: "The email is longer than allowed.");

        public static Error InvalidFormat => Error.Validation(
            code: "Email.InvalidFormat",
            description: "The email format is invalid.");
    }

    public static class FirstName
    {
        public static Error LongerThanAllowed => Error.Validation(
            code: "FirstName.LongerThanAllowed",
            description: "The first name is longer than allowed.");

        public static Error LowerThanAllowed => Error.Validation(
            code: "FirstName.LowerThanAllowed",
            description: "The first name is lower than allowed.");

        public static Error NullOrEmpty => Error.Validation(
            code: "FirstName.NullOrEmpty",
            description: "The first name is required.");
    }

    public static class LastName
    {
        public static Error LongerThanAllowed => Error.Validation(
            code: "LastName.LongerThanAllowed",
            description: "The last name is longer than allowed.");

        public static Error LowerThanAllowed => Error.Validation(
            code: "LastName.LowerThanAllowed",
            description: "The last name is lower than allowed.");

        public static Error NullOrEmpty => Error.Validation(
            code: "LastName.NullOrEmpty",
            description: "The last name is required.");
    }

    public static class UserName
    {
        public static Error LongerThanAllowed => Error.Validation(
            code: "UserName.LongerThanAllowed",
            description: "The username is longer than allowed.");

        public static Error LowerThanAllowed => Error.Validation(
            code: "UserName.LowerThanAllowed",
            description: "The username is lower than allowed.");

        public static Error NullOrEmpty => Error.Validation(
            code: "UserName.NullOrEmpty",
            description: "The username is required.");
    }

    public static class Password
    {
        public static Error NullOrEmpty => Error.Validation(
            code: "Password.NullOrEmpty",
            description: "Password is required."
        );

        public static Error TooShort => Error.Validation(
            code: "Password.TooShort",
            description: "The password is too short.");

        public static Error MissingUppercaseLetter => Error.Validation(
            code: "Password.MissingUppercaseLetter",
            description: "The password requires at least one uppercase letter.");

        public static Error MissingLowercaseLetter => Error.Validation(
            code: "Password.MissingLowercaseLetter",
            description: "The password requires at least one lowercase letter.");

        public static Error MissingDigit => Error.Validation(
            code: "Password.MissingDigit",
            description: "The password requires at least one digit.");

        public static Error MissingNonAlphaNumeric => Error.Validation(
            code: "Password.MissingNonAlphaNumeric",
            description: "The password requires at least one non-alphanumeric.");
    }
}
#pragma warning restore CA1034
