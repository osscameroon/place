namespace Place.Api.Infrastructure.Persistence.EF.Authentication.Repositories;

using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contexts;
using Microsoft.EntityFrameworkCore;
using Models;
using Place.Api.Application.Common.Interfaces.Authentication;
using Place.Api.Domain.Authentication;
using Place.Api.Domain.Authentication.ValueObjects;

public class UserRepository(ReadDbContext readDbContext, WriteDbContext writeDbContext) : IUserRepository
{
    /// <inheritdoc/>
    public async Task<bool> IsUniqueEmail(Email email) =>
        await readDbContext.Users.AnyAsync(user => user.Email == email.Value)
            .ConfigureAwait(false);

    /// <inheritdoc/>
    public async Task AddAsync(User user)
    {
        await writeDbContext.Users.AddAsync(user).ConfigureAwait(true);
        await writeDbContext
            .SaveChangesAsync()
            .ConfigureAwait(true);
    }

    /// <inheritdoc/>
    public async Task<User?> GetByEmail(string email)
    {
        UserReadModel? user = await readDbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email == email)
            .ConfigureAwait(true);

        if (user is null)
        {
            return null;
        }

        return new UserBuilder(
                userName: UserName.Create(user.UserName).Value,
                email: Email.Create(user.Email).Value,
                passwordHash: user.PasswordHash
            )
            .WithId(UserId.Create(user.Id))
            .Build();
    }
}
