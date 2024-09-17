using RTMS.CoreBusiness;

namespace RTMS.UseCases.PluginInterfaces;
public interface IUserRepositoryPostgreEFCore
{
    Task AddTrainerClientRelationshipAsync(Guid clientUserId, Guid trainerUserId);
    Task<User> CreateUserAsync(User user);
    Task<User?> GetUserByAuth0IdAsync(string auth0Id);
    Task<Guid?> GetUserIdByAuth0IdAsync(string Auth0Id);
    Task<User> UpdateUserAsync(User user);
    Task<bool> UserExistsAsync(string auth0Id);
}