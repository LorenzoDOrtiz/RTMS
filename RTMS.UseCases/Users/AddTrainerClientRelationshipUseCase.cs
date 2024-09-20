using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Users.Interfaces;

namespace RTMS.UseCases.Users;

public class AddTrainerClientRelationshipUseCase(IUserRepositoryPostgreEFCore userRepositoryPostgreEF) : IAddTrainerClientRelationshipUseCase
{
    public async Task ExecuteAsync(Guid clientUserId, IEnumerable<Guid> trainerUserId)
    {
        await userRepositoryPostgreEF.AddTrainerClientRelationshipAsync(clientUserId, trainerUserId);
    }
}
