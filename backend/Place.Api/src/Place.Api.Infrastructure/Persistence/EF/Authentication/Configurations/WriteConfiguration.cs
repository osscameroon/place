namespace Place.Api.Infrastructure.Persistence.EF.Authentication.Configurations;

using Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models.Converters;
using Place.Api.Domain;
using Place.Api.Domain.Authentication;
using Place.Api.Domain.Authentication.ValueObjects;

internal sealed class WriteConfiguration : IEntityTypeConfiguration<User>, IEntityTypeConfiguration<UserOTPVerification>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);

        builder.ToTable(Database.Tables.UserTableName);

        builder.Property(user => user.Id)
            .HasConversion<UlidToUserIdConverter>();

        ValueConverter<UserName, string> userNameConverter = new(
            u => u.Value,
            u => UserName.Create(u).Value);

        builder.Property(user => user.UserName)
            .HasConversion(userNameConverter);

        ValueConverter<Email, string> emailConverter = new(
            u => u.Value,
            u => Email.Create(u).Value);

        builder.Property(user => user.Email)
            .IsRequired()
            .HasConversion(emailConverter);

        ValueConverter<FirstName, string> firstNameConverter = new(
            u => u.Value,
            u => FirstName.Create(u).Value);

        builder.Property(user => user.FirstName)
            .HasConversion(firstNameConverter!);


        ValueConverter<LastName, string> lastnameConverter = new(
            u => u.Value,
            u => LastName.Create(u).Value);

        builder.Property(user => user.LastName)
            .HasConversion(lastnameConverter!);

        builder.Property(user => user.EmailIsConfirmed);

        builder.Property(user => user.PasswordHash);

        builder.Property(u => u.CreatedOnUtc);
        builder.Property(u => u.ModifiedOnUtc);
        builder.Property(user => user.DeletedOnUtc);
        builder.Property(user => user.Deleted);
    }

    public void Configure(EntityTypeBuilder<UserOTPVerification> builder)
    {
        builder.HasKey(u => u.Id);

        builder.ToTable(Database.Tables.UserOTPTableName);

        builder.Property(user => user.Id)
            .HasConversion<UlidToUserIdConverter>();

        builder.Property(u => u.CreatedOnUtc);
        builder.Property(u => u.ModifiedOnUtc);
        builder.Property(user => user.DeletedOnUtc);
        builder.Property(user => user.Deleted);
    }
}
