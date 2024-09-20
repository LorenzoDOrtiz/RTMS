using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Users.Interfaces;

namespace RTMS.UseCases.Users;
public class GetClientsAssignedToTrainerUseCase(IUserRepositoryPostgreEFCore userRepositoryPostgreEFCore) : IGetClientsAssignedToTrainerUseCase
{
    public async Task<IEnumerable<User>> ExecuteAsync(Guid userId)
    {
        return await userRepositoryPostgreEFCore.GetClientsAssignedToTrainerUseCase(userId);
    }
}
