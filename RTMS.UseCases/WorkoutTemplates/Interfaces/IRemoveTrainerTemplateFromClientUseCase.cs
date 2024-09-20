namespace RTMS.UseCases.WorkoutTemplates.Interfaces;

public interface IRemoveTrainerTemplateFromClientUseCase
{
    Task ExecuteAsync(int workoutTemplateId, Guid clientId);
}