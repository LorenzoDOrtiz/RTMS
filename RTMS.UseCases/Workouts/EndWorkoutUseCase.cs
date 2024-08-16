using RTMS.Plugins.InMemory;

namespace RTMS.UseCases.Workouts;
public class EndWorkoutUseCase : IEndWorkoutUseCase
{
    private readonly IWorkoutRepository _workoutRepository;

    public EndWorkoutUseCase(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }
    public async Task ExecuteAsync(int workoutId)
    {
        await _workoutRepository.EndWorkoutAsync(workoutId);
    }
}
