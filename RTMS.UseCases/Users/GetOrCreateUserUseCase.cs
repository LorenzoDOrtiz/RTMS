using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Users.Interfaces;

namespace RTMS.UseCases.Users;
public class GetOrCreateUserUseCase(IUserRepositoryPostgreEFCore userRepositoryPostgreEFCore) : IGetOrCreateUserUseCase
{
    public async Task<User> ExecuteAsync(string auth0Id, string email, string name)
    {
        // Check if the user already exists based on Auth0 user ID
        var existingUser = await userRepositoryPostgreEFCore.GetUserByAuth0IdAsync(auth0Id);

        if (existingUser != null)
        {
            // Update the user's details if necessary
            if (existingUser.Email != email || existingUser.Name != name)
            {
                existingUser.Email = email;
                existingUser.Name = name;
                await userRepositoryPostgreEFCore.UpdateUserAsync(existingUser);
            }

            return existingUser;
        }

        // Create a new user if not found
        var newUser = new User
        {
            Auth0Id = auth0Id,
            Email = email,
            Name = name
        };

        await userRepositoryPostgreEFCore.CreateUserAsync(newUser);

        return newUser;
    }
}