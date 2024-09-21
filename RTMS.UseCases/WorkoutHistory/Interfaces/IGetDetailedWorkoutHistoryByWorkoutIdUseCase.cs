using RTMS.CoreBusiness;

namespace RTMS.UseCases.WorkoutHistory.Interfaces;
public interface IGetDetailedWorkoutHistoryByWorkoutIdUseCase
{
    Task<Workout> ExecuteAsync(int workoutId);
}