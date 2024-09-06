namespace RTMS.UseCases.WorkoutTemplates.Interfaces;

public interface IDeleteWorkoutTemplateUseCase
{
    Task ExecuteAsync(int workoutTemplateId);
}