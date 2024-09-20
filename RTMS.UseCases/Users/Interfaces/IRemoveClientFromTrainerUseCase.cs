namespace RTMS.UseCases.Users.Interfaces;

public interface IRemoveClientFromTrainerUseCase
{
    Task ExecuteAsync(Guid clientId, Guid trainerId);
}