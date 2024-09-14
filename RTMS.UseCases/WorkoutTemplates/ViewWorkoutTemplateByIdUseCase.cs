using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.WorkoutTemplates.Interfaces;

namespace RTMS.UseCases.WorkoutTemplates;
public class ViewWorkoutTemplateByIdUseCase(IWorkoutTemplateRepository workoutRepository) : IViewWorkoutTemplateByIdUseCase
{
    public async Task<WorkoutTemplate> ExecuteAsync(int id)
    {
        return await workoutRepository.GetWorkoutTemplateByIdAsync(id);
    }
}