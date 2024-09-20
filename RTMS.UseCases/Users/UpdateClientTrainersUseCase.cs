using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Users.Interfaces;

namespace RTMS.UseCases.Users;
public class UpdateClientTrainersUseCase(IUserRepositoryPostgreEFCore userRepositoryPostgreEFCore) : IUpdateClientTrainersUseCase
{
    public async Task ExecuteAsync(Guid userId, IEnumerable<Guid> trainerIds)
    {
        userRepositoryPostgreEFCore.UpdateClientTrainers(userId, trainerIds);
    }
}
