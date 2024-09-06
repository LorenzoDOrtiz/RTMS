using RTMS.CoreBusiness;
using RTMS.UseCases.ActiveWorkouts.Interfaces;
using RTMS.UseCases.PluginInterfaces;

namespace RTMS.UseCases.ActiveWorkouts;

public class ViewWorkoutHistoryByUserIdUseCase(IWorkoutHistoryRepository workoutRepository) : IViewWorkoutHistoryByUserIdUseCase
{
    public async Task<List<Workout>> ExecuteAsync(string userId)
    {
        return await workoutRepository.ViewWorkoutHistoryByUserIdAsync(userId);
    }
}
