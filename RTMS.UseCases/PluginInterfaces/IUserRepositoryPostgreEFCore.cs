using RTMS.CoreBusiness;

namespace RTMS.UseCases.PluginInterfaces;
public interface IUserRepositoryPostgreEFCore
{
    Task AddTrainerClientRelationshipAsync(Guid clientUserId, IEnumerable<Guid> trainerUserId);
    Task<User> CreateUserAsync(User user);
    Task<User?> GetUserByAuth0IdAsync(string auth0Id);
    Task<IEnumerable<Guid>?> GetTrainerIdsByUserIdAsync(Guid userId);
    Task<Guid> GetUserIdByAuth0IdAsync(string Auth0Id);
    Task<IEnumerable<Guid>?> GetUserIdsByAuth0IdsAsync(IEnumerable<string> auth0Id);
    Task<User> UpdateUserAsync(User user);
    Task<bool> UserExistsAsync(string auth0Id);
    Task<IEnumerable<string>?> GetAuth0UserIdsByUserIds(IEnumerable<Guid> userIds);
    void UpdateClientTrainers(Guid userId, IEnumerable<Guid> trainerIds);
    Task<IEnumerable<User>> GetClientsAssignedToTrainerUseCase(Guid trainerUserId);
    Task RemoveClientFromTrainerUseCase(Guid clientId, Guid trainerId);
    Task DeleteUserAsync(Guid userId);
}