using Microsoft.EntityFrameworkCore;
using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;

namespace RTMS.Plugins.PostgreEFCore
{
    public class UserRepositoryPostgreEFCore(IDbContextFactory<RTMSDBContext> contextFactory) : IUserRepositoryPostgreEFCore
    {

        // Get a user by Auth0 ID (or any other identifier like email)
        public async Task<User?> GetUserByAuth0IdAsync(string auth0Id)
        {
            using var context = contextFactory.CreateDbContext();
            return await context.Users
                .AsNoTracking() // Use AsNoTracking to improve performance if the entity isn't being updated
                .FirstOrDefaultAsync(u => u.Auth0Id == auth0Id);
        }

        // Create a new user
        public async Task<User> CreateUserAsync(User user)
        {
            using var context = contextFactory.CreateDbContext();
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }

        // Update an existing user
        public async Task<User> UpdateUserAsync(User user)
        {
            using var context = contextFactory.CreateDbContext();
            context.Users.Update(user);
            await context.SaveChangesAsync();
            return user;
        }

        // Check if a user exists by their Auth0 ID
        public async Task<bool> UserExistsAsync(string auth0Id)
        {
            using var context = contextFactory.CreateDbContext();
            return await context.Users
                .AnyAsync(u => u.Auth0Id == auth0Id);
        }

        // Get a user by their internal ID (for example, when managing local user IDs)
        public async Task<User?> GetUserByIdAsync(Guid userId)
        {
            using var context = contextFactory.CreateDbContext();
            return await context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
}
