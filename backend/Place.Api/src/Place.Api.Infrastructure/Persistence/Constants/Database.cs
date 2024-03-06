namespace Place.Api.Infrastructure.Persistence.Constants;

/// <summary>
/// Contains definitions related to the database structure.
/// </summary>
internal static class Database
{
    /// <summary>
    /// Contains constants representing the names of the database tables.
    /// </summary>
    internal static class Tables
    {
        /// <summary>
        /// Gets the name of the user table.
        /// </summary>
        public static string UserTableName => "users";

        /// <summary>
        /// Gets the name of the user otp table.
        /// </summary>
        public static string UserOTPTableName => "users_otp";
    }
}

