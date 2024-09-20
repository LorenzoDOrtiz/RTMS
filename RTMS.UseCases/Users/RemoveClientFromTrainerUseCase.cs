using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Users.Interfaces;

namespace RTMS.UseCases.Users;
public class RemoveClientFromTrainerUseCase(IUserRepositoryPostgreEFCore userRepositoryPostgreEFCore) : IRemoveClientFromTrainerUseCase
{
    public async Task ExecuteAsync(Guid clientId, Guid trainerId)
    {
        userRepositoryPostgreEFCore.RemoveClientFromTrainerUseCase(clientId, trainerId);
    }
}
