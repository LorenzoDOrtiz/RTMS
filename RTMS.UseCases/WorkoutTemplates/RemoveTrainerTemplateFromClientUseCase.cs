using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.WorkoutTemplates.Interfaces;

namespace RTMS.UseCases.WorkoutTemplates;
public class RemoveTrainerTemplateFromClientUseCase(IWorkoutTemplateRepository workoutTemplateRepository) : IRemoveTrainerTemplateFromClientUseCase
{
    public async Task ExecuteAsync(int workoutTemplateId, Guid clientId)
    {
        await workoutTemplateRepository.RemoveTrainerTemplateFromClientAsync(workoutTemplateId, clientId);
    }
}
