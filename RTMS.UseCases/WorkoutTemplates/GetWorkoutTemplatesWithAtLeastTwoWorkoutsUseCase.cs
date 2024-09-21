using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.WorkoutTemplates.Interfaces;

namespace RTMS.UseCases.WorkoutTemplates;
public class GetWorkoutTemplatesWithAtLeastTwoWorkoutsUseCase(IWorkoutTemplateRepository workoutTemplateRepository) : IGetWorkoutTemplatesWithAtLeastTwoWorkoutsUseCase
{
    public async Task<IEnumerable<WorkoutTemplate>> ExecuteAsync(Guid userId)
    {
        return await workoutTemplateRepository.GetWorkoutTemplatesWithAtLeastTwoWorkoutsAsync(userId);
    }
}
