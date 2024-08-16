
namespace RTMS.UseCases.Workouts;

public interface IEndWorkoutUseCase
{
    Task ExecuteAsync(int workoutId);
}