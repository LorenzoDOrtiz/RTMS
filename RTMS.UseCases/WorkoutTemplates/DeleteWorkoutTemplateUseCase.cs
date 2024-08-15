using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.WorkoutTemplates.Interfaces;

namespace RTMS.UseCases.WorkoutTemplates;
public class DeleteWorkoutTemplateUseCase : IDeleteWorkoutTemplateUseCase
{
    private readonly IWorkoutTemplateRepository _workoutRepository;

    public DeleteWorkoutTemplateUseCase(IWorkoutTemplateRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public async Task ExecuteAsync(int workoutId)
    {
        await _workoutRepository.DeleteWorkoutTemplateAsync(workoutId);
    }
}
