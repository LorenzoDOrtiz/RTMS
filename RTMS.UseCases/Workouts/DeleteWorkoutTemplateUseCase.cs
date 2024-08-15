using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Workouts.Interfaces;

namespace RTMS.UseCases.Workouts;
public class DeleteWorkoutTemplateUseCase : IDeleteWorkoutTemplateUseCase
{
    private readonly IWorkoutRepository _workoutRepository;

    public DeleteWorkoutTemplateUseCase(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public async Task ExecuteAsync(int workoutId)
    {
        await _workoutRepository.DeleteWorkoutAsync(workoutId);
    }
}
