using RTMS.CoreBusiness;

namespace RTMS.UseCases.Users.Interfaces;
public interface IGetOrCreateUserUseCase
{
    Task<User> ExecuteAsync(string auth0UserId, string firstName, string LastName, string userEmail);
}