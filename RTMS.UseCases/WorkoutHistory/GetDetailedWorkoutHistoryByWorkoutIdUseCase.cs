using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.WorkoutHistory.Interfaces;

namespace RTMS.UseCases.WorkoutHistory;
public class GetDetailedWorkoutHistoryByWorkoutIdUseCase(IWorkoutHistoryRepository workoutHistoryRepository) : IGetDetailedWorkoutHistoryByWorkoutIdUseCase
{
    public async Task<Workout> ExecuteAsync(int workoutId)
    {
        return await workoutHistoryRepository.GetDetailedWorkoutHistoryByWorkoutIdAsync(workoutId);
    }
}
