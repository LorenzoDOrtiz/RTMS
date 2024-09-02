using RTMS.CoreBusiness.WorkoutTemplate;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.WorkoutTemplates.Interfaces;

namespace RTMS.UseCases.WorkoutTemplates;
public class EditWorkoutTemplateUseCase(IWorkoutTemplateRepository workoutRepository) : IEditWorkoutTemplateUseCase
{
    public async Task ExecuteAsync(WorkoutTemplate workout)
    {
        await workoutRepository.UpdateWorkoutTemplateAsync(workout);
    }
}
