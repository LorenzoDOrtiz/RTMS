using RTMS.CoreBusiness.WorkoutTemplate;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.WorkoutTemplates.Interfaces;

namespace RTMS.UseCases.WorkoutTemplates;
public class ViewWorkoutTemplateByIdUseCase(IWorkoutTemplateRepository workoutRepository) : IViewWorkoutTemplateUseCase
{
    public async Task<WorkoutTemplate> ExecuteAsync(int id)
    {
        return await workoutRepository.GetWorkoutTemplateByIdAsync(id);
    }
}