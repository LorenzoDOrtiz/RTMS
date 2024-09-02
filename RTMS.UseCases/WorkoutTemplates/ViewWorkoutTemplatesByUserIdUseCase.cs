using RTMS.CoreBusiness.WorkoutTemplate;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.WorkoutTemplates.Interfaces;

namespace RTMS.UseCases.WorkoutTemplates;
public class ViewWorkoutTemplatesByUserIdUseCase(IWorkoutTemplateRepository workoutRepository) : IViewWorkoutTemplatesByUserIdUseCase
{
    public async Task<IEnumerable<WorkoutTemplate>> ExecuteAsync(Guid userId)
    {
        return await workoutRepository.GetWorkoutTemplatesByUserIdAsync(userId);
    }
}
