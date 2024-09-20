using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.WorkoutTemplates.Interfaces;

namespace RTMS.UseCases.WorkoutTemplates;
public class ViewClientWorkoutTemplatesUseCase(IWorkoutTemplateRepository workoutTemplateRepository) : IViewClientWorkoutTemplatesUseCase
{
    public async Task<List<WorkoutTemplate>> ExecuteAsync(Guid clientId)
    {
        return await workoutTemplateRepository.ViewClientWorkoutTemplatesAsync(clientId);
    }
}
