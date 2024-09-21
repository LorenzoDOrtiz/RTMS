using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.WorkoutHistory.Interfaces;

namespace RTMS.UseCases.WorkoutHistory;
public class GetDetailedExerciseHistoryByTemplateIdUseCase(IWorkoutHistoryRepository workoutHistoryRepository) : IGetDetailedExerciseHistoryByTemplateIdUseCase
{
    public async Task<IEnumerable<Exercise>> ExecuteAsync(int templateId)
    {
        return await workoutHistoryRepository.GetDetailedExerciseHistoryByTemplateId(templateId);
    }
}
