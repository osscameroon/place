namespace Place.Api.Infrastructure.Persistence.EF.Contexts;

using Authentication.Configurations;
using Microsoft.EntityFrameworkCore;
using Place.Api.Domain;
using Place.Api.Domain.Authentication;
using Place.Api.Infrastructure.Persistence.Interceptors;


/// <summary>
/// Represents the database context for write operations.
/// </summary>
public sealed class WriteDbContext(DbContextOptions<WriteDbContext> options,
        UpdateAuditableEntitiesInterceptor updateAuditableEntitiesInterceptor,
        SoftDeleteInterceptor softDeleteInterceptor)
    : DbContext(options)
{
    /// <summary>
    /// Gets or sets the DbSet for User entities.
    /// </summary>
    public DbSet<User> Users { get; set; } = null!;

    /// <summary>
    /// Gets or sets the DbSet for UserOTPVerification entities.
    /// </summary>
    public DbSet<UserOTPVerification> UsersOTPVerifation { get; set; } = null!;


    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("place");
        WriteConfiguration configuration = new WriteConfiguration();
        modelBuilder.ApplyConfiguration(configuration);

        base.OnModelCreating(modelBuilder);
    }


    /// <inheritdoc/>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .AddInterceptors(softDeleteInterceptor)
            .AddInterceptors(updateAuditableEntitiesInterceptor);

        base.OnConfiguring(optionsBuilder);
    }
}
