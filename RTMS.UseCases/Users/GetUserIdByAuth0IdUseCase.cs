using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Users.Interfaces;

namespace RTMS.UseCases.Users;
public class GetUserIdByAuth0IdUseCase(IUserRepositoryPostgreEFCore userRepositoryPostgreEFCore) : IGetUserIdByAuth0IdUseCase
{
    public async Task<Guid?> ExecuteAsync(string Auth0Id)
    {
        return await userRepositoryPostgreEFCore.GetUserIdByAuth0IdAsync(Auth0Id);
    }
}
