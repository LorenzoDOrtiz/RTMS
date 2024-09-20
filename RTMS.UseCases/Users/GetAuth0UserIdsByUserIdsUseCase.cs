using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Users.Interfaces;

namespace RTMS.UseCases.Users;
public class GetAuth0UserIdsByUserIdsUseCase(IUserRepositoryPostgreEFCore userRepositoryPostgreEFCore) : IGetAuth0UserIdsByUserIdsUseCase
{
    public async Task<IEnumerable<string>?> ExecuteAsync(IEnumerable<Guid> userIds)
    {
        return await userRepositoryPostgreEFCore.GetAuth0UserIdsByUserIds(userIds);
    }
}
