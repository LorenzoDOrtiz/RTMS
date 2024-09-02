using RTMS.Plugins.InMemory;
using RTMS.UseCases.Workouts;

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