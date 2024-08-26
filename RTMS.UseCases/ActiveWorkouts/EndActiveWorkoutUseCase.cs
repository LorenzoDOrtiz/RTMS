using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Workouts;

namespace RTMS.UseCases.ActiveWorkouts;

public class EndActiveWorkoutUseCase : IEndActiveWorkoutUseCase
{
    private readonly IWorkoutRepository _workoutRepository;

    public EndActiveWorkoutUseCase(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public async Task ExecuteAsync(int workoutId)
    {
        await _workoutRepository.EndWorkoutAsync(workoutId);
    }
}