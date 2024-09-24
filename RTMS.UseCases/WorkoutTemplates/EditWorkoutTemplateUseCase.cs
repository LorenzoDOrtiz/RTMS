using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.WorkoutTemplates.Interfaces;

namespace RTMS.UseCases.WorkoutTemplates;
public class EditWorkoutTemplateUseCase(IWorkoutTemplateRepository workoutRepository) : IEditWorkoutTemplateUseCase
{
    public async Task<WorkoutTemplate> ExecuteAsync(WorkoutTemplate workoutTemplate)
    {
        return await workoutRepository.UpdateWorkoutTemplateAsync(workoutTemplate);
    }
}
