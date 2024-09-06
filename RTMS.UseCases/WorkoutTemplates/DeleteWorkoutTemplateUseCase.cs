using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.WorkoutTemplates.Interfaces;

namespace RTMS.UseCases.WorkoutTemplates;
public class DeleteWorkoutTemplateUseCase(IWorkoutTemplateRepository workoutRepository) : IDeleteWorkoutTemplateUseCase
{
    public async Task ExecuteAsync(int workoutTemplateId)
    {
        await workoutRepository.DeleteWorkoutTemplateAsync(workoutTemplateId);
    }
}
