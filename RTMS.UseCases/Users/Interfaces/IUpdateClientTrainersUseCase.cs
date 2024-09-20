
namespace RTMS.UseCases.Users.Interfaces;

public interface IUpdateClientTrainersUseCase
{
    Task ExecuteAsync(Guid userId, IEnumerable<Guid> trainerIds);
}