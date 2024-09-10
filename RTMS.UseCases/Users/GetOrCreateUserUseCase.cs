using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Users.Interfaces;

namespace RTMS.UseCases.Users;
public class GetOrCreateUserUseCase(IUserRepositoryPostgreEFCore userRepositoryPostgreEFCore) : IGetOrCreateUserUseCase
{
    public async Task<User> ExecuteAsync(string provider, string providerKey, string email, string name)
    {
        return await userRepositoryPostgreEFCore.GetOrCreateUserAsync(provider, providerKey, email, name);
    }
}
