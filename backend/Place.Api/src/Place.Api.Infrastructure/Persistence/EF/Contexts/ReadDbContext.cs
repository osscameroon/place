namespace Place.Api.Infrastructure.Persistence.EF.Contexts
{
    using Authentication.Configurations;
    using Authentication.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Represents the database context for read operations.
    /// </summary>
    public sealed class ReadDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReadDbContext"/> class.
        /// </summary>
        /// <param name="options">The options for configuring the database context.</param>
        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the DbSet for UserReadModel entities.
        /// </summary>
        public DbSet<UserReadModel> Users { get; set; } = null!;

        /// <summary>
        /// Gets or sets the DbSet for UserOTPVerificationReadModel entities.
        /// </summary>
        public DbSet<UserOTPVerificationReadModel> UsersOTPVerification { get; set; } = null!;

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set the default schema for the database
            modelBuilder.HasDefaultSchema("place");

            // Apply configurations for read models
            ReadConfiguration configuration = new();
            modelBuilder.ApplyConfiguration(configuration);

            base.OnModelCreating(modelBuilder);
        }
    }
}
