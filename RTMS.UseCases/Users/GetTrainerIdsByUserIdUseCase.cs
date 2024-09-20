using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Users.Interfaces;

namespace RTMS.UseCases.Users;
public class GetTrainerIdsByUserIdUseCase(IUserRepositoryPostgreEFCore userRepositoryPostgreEFCore) : IGetTrainerIdsByUserIdUseCase
{
    public async Task<IEnumerable<Guid>?> ExecuteAsync(Guid userId)
    {
        return await userRepositoryPostgreEFCore.GetTrainerIdsByUserIdAsync(userId);
    }
}
