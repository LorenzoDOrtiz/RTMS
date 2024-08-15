
namespace RTMS.UseCases.Workouts.Interfaces;

public interface IDeleteWorkoutTemplateUseCase
{
    Task ExecuteAsync(int workoutId);
}