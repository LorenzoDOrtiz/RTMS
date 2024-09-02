using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Workouts;

namespace RTMS.UseCases.ActiveWorkouts;

public class EndActiveWorkoutUseCase : IEndActiveWorkoutUseCase
{
    private readonly IActiveWorkoutRepository _workoutRepository;

    public EndActiveWorkoutUseCase(IActiveWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public async Task ExecuteAsync(int workoutId)
    {
        await _workoutRepository.EndWorkoutAsync(workoutId);
    }
}