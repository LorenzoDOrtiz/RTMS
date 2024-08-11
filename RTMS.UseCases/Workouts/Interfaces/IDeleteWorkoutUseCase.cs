
namespace RTMS.UseCases.Workouts.Interfaces;

public interface IDeleteWorkoutUseCase
{
    Task ExecuteAsync(int workoutId);
}