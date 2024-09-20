
namespace RTMS.UseCases.Users.Interfaces;

public interface IGetUserIdsByAuth0IdsUseCase
{
    Task<IEnumerable<Guid>?> ExecuteAsync(IEnumerable<string> Auth0Id);
}