using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Workouts.Interfaces;

namespace RTMS.UseCases.ActiveWorkouts;

public class ViewActiveWorkoutByIdUseCase(IWorkoutHistoryRepository workoutRepository) : IViewActiveWorkoutByIdUseCase
{
    public async Task<Workout> ExecuteAsync(string userId)
    {
        return await workoutRepository.ViewActiveWorkoutByUserIdAsync(userId);

    }
}
