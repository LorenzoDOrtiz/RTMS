using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Users.Interfaces;

namespace RTMS.UseCases.Users;
public class GetUserIdsByAuth0IdsUseCase(IUserRepositoryPostgreEFCore userRepositoryPostgreEFCore) : IGetUserIdsByAuth0IdsUseCase
{
    public async Task<IEnumerable<Guid>?> ExecuteAsync(IEnumerable<string> Auth0Id)
    {
        return await userRepositoryPostgreEFCore.GetUserIdsByAuth0IdsAsync(Auth0Id);
    }
}
