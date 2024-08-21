
namespace RTMS.UseCases.Workouts;

public interface IEndActiveWorkoutUseCase
{
    Task ExecuteAsync(int workoutId);
}