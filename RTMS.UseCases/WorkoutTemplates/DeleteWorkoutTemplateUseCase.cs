using RTMS.CoreBusiness.Template;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.WorkoutTemplates.Interfaces;

namespace RTMS.UseCases.WorkoutTemplates;
public class DeleteWorkoutTemplateUseCase(IWorkoutTemplateRepository workoutRepository) : IDeleteWorkoutTemplateUseCase
{
    public async Task ExecuteAsync(int workoutId)
    {
        await _workoutRepository.DeleteWorkoutTemplateAsync(workoutId);
    }
}
