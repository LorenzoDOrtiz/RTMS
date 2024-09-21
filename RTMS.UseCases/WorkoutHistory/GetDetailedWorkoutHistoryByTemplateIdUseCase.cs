using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.WorkoutHistory.Interfaces;

namespace RTMS.UseCases.WorkoutHistory;

public class GetDetailedWorkoutHistoryByTemplateIdUseCase(IWorkoutHistoryRepository workoutHistoryRepository) : IGetDetailedWorkoutHistoryByTemplateIdUseCase
{
    public async Task<IEnumerable<Workout>> ExecuteAsync(int templateId)
    {
        return await workoutHistoryRepository.GetDetailedWorkoutHistoryByTemplateIdAsync(templateId);
    }
}
