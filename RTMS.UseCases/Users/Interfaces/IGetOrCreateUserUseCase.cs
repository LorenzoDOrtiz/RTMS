using RTMS.CoreBusiness;

namespace RTMS.UseCases.Users.Interfaces;
public interface IGetOrCreateUserUseCase
{
    Task<User> ExecuteAsync(string provider, string providerKey, string email, string name);
}