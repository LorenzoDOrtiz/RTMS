using RTMS.Plugins.InMemory;
using RTMS.UseCases.Workouts;

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