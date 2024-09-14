using RTMS.CoreBusiness;

namespace RTMS.UseCases.Workouts.Interfaces;

public interface IViewActiveWorkoutByWorkoutAndUserIdUseCase
{
    Task<Workout> ExecuteAsync(int workoutId, Guid userId);
}