using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Workouts.Interfaces;

namespace RTMS.UseCases.Workouts;
public class DeleteWorkoutUseCase : IDeleteWorkoutUseCase
{
    private readonly IWorkoutRepository _workoutRepository;

    public DeleteWorkoutUseCase(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public async Task ExecuteAsync(int workoutId)
    {
        await _workoutRepository.DeleteWorkoutAsync(workoutId);
    }
}
