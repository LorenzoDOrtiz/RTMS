
namespace RTMS.UseCases.Users.Interfaces;

public interface IGetUserIdByAuth0IdUseCase
{
    Task<Guid?> ExecuteAsync(string Auth0Id);
}