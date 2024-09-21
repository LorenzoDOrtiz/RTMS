using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.WorkoutHistory.Interfaces;

namespace RTMS.UseCases.WorkoutHistory;

public class ViewWorkoutHistoryByUserIdUseCase(IWorkoutHistoryRepository workoutRepository) : IViewWorkoutHistoryByUserIdUseCase
{
    public async Task<List<Workout>> ExecuteAsync(Guid userId)
    {
        return await workoutRepository.ViewWorkoutHistoryByUserIdAsync(userId);
    }
}
