using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.WorkoutHistory.Interfaces;

namespace RTMS.UseCases.WorkoutHistory;
public class GetExerciseTemplatesWithAtLeastTwoExercisesUseCase(IWorkoutTemplateRepository workoutHistoryRepository) : IGetExerciseTemplatesWithAtLeastTwoExercisesUseCase
{
    public async Task<IEnumerable<ExerciseTemplate>> ExecuteAsync(Guid userId)
    {
        return await workoutHistoryRepository.GetExerciseTemplatesWithAtLeastTwoExercisesAsync(userId);
    }
}
