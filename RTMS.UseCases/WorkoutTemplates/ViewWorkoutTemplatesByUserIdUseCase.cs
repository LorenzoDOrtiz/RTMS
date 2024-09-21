using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.WorkoutTemplates.Interfaces;

namespace RTMS.UseCases.WorkoutTemplates;
public class ViewWorkoutTemplatesByUserIdUseCase(IWorkoutTemplateRepository workoutTemplateRepository) : IViewWorkoutTemplatesByUserIdUseCase
{
    public async Task<IEnumerable<WorkoutTemplate>> ExecuteAsync(Guid userId)
    {
        return await workoutTemplateRepository.GetWorkoutTemplatesByUserIdAsync(userId);
    }
}
