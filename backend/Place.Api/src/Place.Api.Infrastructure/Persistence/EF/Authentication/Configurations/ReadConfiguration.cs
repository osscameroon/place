namespace Place.Api.Infrastructure.Persistence.EF.Authentication.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using Models.Converters;
using Place.Api.Domain.Authentication.ValueObjects;
using Place.Api.Infrastructure.Persistence.Constants;

internal sealed class ReadConfiguration : IEntityTypeConfiguration<UserReadModel>, IEntityTypeConfiguration<UserOTPVerificationReadModel>
{
    public void Configure(EntityTypeBuilder<UserReadModel> builder)
    {
        builder.ToTable(Database.Tables.UserTableName);

        builder.Property(user => user.Id)
            .HasConversion<UlidToStringConverter>();


        builder.Property(user => user.UserName)
            .IsRequired()
            .HasMaxLength(UserName.MaxLength);

        builder.Property(user => user.Email)
            .IsRequired()
            .HasMaxLength(Email.MaxLength);
        builder.HasIndex(user => user.Email)
            .IsUnique();

        builder.Property(user => user.FirstName)
            .IsRequired(false)
            .HasMaxLength(FirstName.MaxLength);

        builder.Property(user => user.LastName)
            .IsRequired(false)
            .HasMaxLength(LastName.MaxLength);
        builder.Property(user => user.EmailIsConfirmed)
            .IsRequired();
        builder.HasIndex(user => user.EmailIsConfirmed);

        builder.Property(user => user.PasswordHash)
            .IsRequired();

        builder.Property(user => user.CreatedOnUtc)
            .IsRequired();

        builder.Property(user => user.DeletedOnUtc);
        builder.Property(user => user.Deleted);

        builder.HasKey(user => user.Id);

    }

    public void Configure(EntityTypeBuilder<UserOTPVerificationReadModel> builder)
    {
        builder.ToTable(Database.Tables.UserOTPTableName);

        builder.Property(userOTP => userOTP.Id)
            .HasConversion<UlidToStringConverter>();

        builder.Property(userOTP => userOTP.UserId)
            .HasConversion<UlidToStringConverter>()
            .IsRequired();

        builder.Property(userOTP => userOTP.OTP)
            .IsRequired();

        builder.Property(userOTP => userOTP.CreatedOnUtc)
            .IsRequired();

        builder.Property(userOTP => userOTP.DeletedOnUtc);
        builder.Property(userOTP => userOTP.Deleted);

        builder.HasKey(userOTP => userOTP.Id);
    }
}
