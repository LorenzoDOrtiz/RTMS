using Microsoft.EntityFrameworkCore;
using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;

namespace RTMS.Plugins.PostgreEFCore;

public class UserRepositoryPostgreEFCore(IDbContextFactory<RTMSDBContext> contextFactory) : IUserRepositoryPostgreEFCore
{
    public async Task<User> GetOrCreateUserAsync(string provider, string providerKey, string email, string name)
    {
        using var context = contextFactory.CreateDbContext();

        // Check if the user login already exists based on provider and provider key
        var existingUserLogin = await context.UserLogins
            .Include(ul => ul.User)
            .FirstOrDefaultAsync(ul => ul.Provider == provider && ul.ProviderKey == providerKey);

        if (existingUserLogin != null)
        {
            // If the login already exists, check if the associated user's name and email match
            var user = existingUserLogin.User;

            if (user.Email != email || user.Name != name)
            {
                // Update the user's details if they don't match
                user.Email = email;
                user.Name = name;

                // Save the changes
                context.Users.Update(user);
                await context.SaveChangesAsync();
            }

            // Return the updated user
            return user;
        }

        // Create a new user if no login was found
        var newUser = new User
        {
            Name = name,
            Email = email
        };

        // Add the new user to the database
        context.Users.Add(newUser);
        await context.SaveChangesAsync();

        // Now create the UserLogin record associated with this user
        var newUserLogin = new UserLogin
        {
            Provider = provider,
            ProviderKey = providerKey,
            UserId = newUser.Id // Associate the login with the newly created user
        };

        context.UserLogins.Add(newUserLogin);
        await context.SaveChangesAsync();

        return newUser;
    }
}
