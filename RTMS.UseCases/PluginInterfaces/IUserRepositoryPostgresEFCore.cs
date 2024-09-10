using RTMS.CoreBusiness;

namespace RTMS.UseCases.PluginInterfaces;
public interface IUserRepositoryPostgreEFCore
{
    Task<User> GetOrCreateUserAsync(string provider, string providerKey, string email, string name);
}