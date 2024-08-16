namespace RTMS.UseCases.Workouts.Interfaces;

public interface IViewWorkoutByIdUseCase
{
    Task ExecuteAsync(int workoutId);
}