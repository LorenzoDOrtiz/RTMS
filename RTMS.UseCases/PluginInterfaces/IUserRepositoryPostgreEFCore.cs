using RTMS.CoreBusiness;

namespace RTMS.UseCases.PluginInterfaces;
public interface IUserRepositoryPostgreEFCore
{
    Task<User> CreateUserAsync(User user);
    Task<User?> GetUserByAuth0IdAsync(string auth0Id);
    Task<User?> GetUserByIdAsync(Guid userId);
    Task<User> UpdateUserAsync(User user);
    Task<bool> UserExistsAsync(string auth0Id);
}