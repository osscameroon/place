namespace Place.Api.Application.Authentication.ForgotPassword;

using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Interfaces.Authentication;
using Domain.Authentication;
using Domain.Authentication.ValueObjects;
using ErrorOr;
using MediatR;

public sealed class ForgotPasswordRequestHandler : IRequestHandler<ForgotPasswordCommand, ErrorOr<SendOTPResult>>
{
    private readonly IUserRepository userRepository;
    public ForgotPasswordRequestHandler(IUserRepository userRepository) => this.userRepository = userRepository;

    public async Task<ErrorOr<SendOTPResult>> Handle(
        ForgotPasswordCommand request,
        CancellationToken cancellationToken
    )
    {
        ErrorOr<Email> email = Email.Create(request.Email);

        if (email.IsError)
        {
            return email.FirstError;
        }

        bool isEmailExist = await this.userRepository
            .IsUniqueEmail(email.Value)
            .ConfigureAwait(false);

        if (!isEmailExist)
        {
            return DomainErrors.User.NotFoundEmail;
        }

        // TODO: Implement send password recovery method
        bool otpSent = SendRecoveryMail(email.Value);

        User user = await this.userRepository
            .GetByEmail(email.Value)
            .ConfigureAwait(false);

        return new SendOTPResult(otpSent);
    }

    private static bool SendRecoveryMail(Email email)
    {
#pragma warning disable CA1031 // Do not catch general exception types
        try
        {

            // instantiate Random class
            Random random = new();

            // generate a random number
#pragma warning disable CA5394 // Do not use insecure randomness
            int otp = random.Next(1000, 9999);
#pragma warning restore CA5394 // Do not use insecure randomness


            Console.WriteLine("Email sent to: " + email);

            // TODO: Implement send mail here
            // hash the otp and store in database before sending

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed to send otp: " + e);
            return false;
        }
#pragma warning restore CA1031 // Do not catch general exception types

    }
}
