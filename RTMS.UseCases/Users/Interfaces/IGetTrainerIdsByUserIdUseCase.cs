namespace RTMS.UseCases.Users.Interfaces;

public interface IGetTrainerIdsByUserIdUseCase
{
    Task<IEnumerable<Guid>?> ExecuteAsync(Guid userId);
}