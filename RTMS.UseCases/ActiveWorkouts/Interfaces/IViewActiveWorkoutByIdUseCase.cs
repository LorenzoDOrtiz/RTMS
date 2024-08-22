namespace RTMS.UseCases.Workouts.Interfaces;

public interface IViewActiveWorkoutByIdUseCase
{
    Task ExecuteAsync(int workoutId);
}