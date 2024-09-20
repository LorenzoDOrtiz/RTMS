
namespace RTMS.UseCases.Users.Interfaces;

public interface IGetAuth0UserIdsByUserIdsUseCase
{
    Task<IEnumerable<string>?> ExecuteAsync(IEnumerable<Guid> userIds);
}