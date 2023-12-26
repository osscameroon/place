namespace Place.Api.Presentation.Endpoints;

#pragma warning disable CA1034
public static class ApiRoutes
{
    public static class Register
    {
        public const string Endpoint = "regsiter";
        public const string Summary = "Registers a new user";
        public const string OperationId = "RegisterUser";
        public static readonly string[] Tags = { "Authentication", "Register" };
        public const string Description = "Allows users to create a new account by providing their registration details. Upon successful registration, the system will generate unique credentials, and the user will gain access to the platform's features";
        public const string SuccessMessage = "User created successfuly";
    }

    public static class Login
    {
        public const string Endpoint = "login";
        public const string Summary = "Authenticates a user";
        public const string OperationId = "AuthenticateUser";
        public static readonly string[] Tags = { "Authentication", "Login" };
        public const string Description = "Authenticates a user. Upon successful registration, the system will generate unique credentials, and the user will gain access to the platform's features";
        public const string SuccessMessage = "User authenticated successfuly";
    }
    public static class ForgotPassword
    {
        public const string Endpoint = "forgotpassword";
        public const string Summary = "Recovers a user's account";
        public const string OperationId = "RecoverUser";
        public static readonly string[] Tags = { "Authentication", "ForgotPassword" };
        public const string Description = "Allows users to recover their account by sending a one-time password reset (OTP) by mail and validating the reset password";
        public const string SuccessMessage = "OTP sent successfully";
    }

    public static class VerifyOTP
    {
        public const string Endpoint = "verifyotp";
        public const string Summary = "Recovers a user's account";
        public const string OperationId = "RecoverUser";
        public static readonly string[] Tags = { "Authentication", "VerifyOTP" };
        public const string Description = "Allows users to verify the otp sent by mail inorder to permit him/her to change the password.";
        public const string SuccessMessage = "OTP verified successfully";
    }

    public static class ResetPassword
    {
        public const string Endpoint = "resetpassword";
        public const string Summary = "Change a user's password after otp verification";
        public const string OperationId = "RecoverUser";
        public static readonly string[] Tags = { "Authentication", "ResetPassword" };
        public const string Description = "Allows users to change their password after forgetting their password and verifying the otp.";
        public const string SuccessMessage = "New password saved successfully";
    }

}

#pragma warning restore CA1034
