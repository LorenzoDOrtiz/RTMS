using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Workouts.Interfaces;

namespace RTMS.UseCases.ActiveWorkouts;

public class ViewActiveWorkoutByWorkoutAndUserIdUseCase(IWorkoutHistoryRepository workoutRepository) : IViewActiveWorkoutByWorkoutAndUserIdUseCase
{
    public async Task<Workout> ExecuteAsync(int workoutId, Guid userId)
    {
        return await workoutRepository.ViewActiveWorkoutByWorkoutAndUserIdAsync(workoutId, userId);

    }
}
