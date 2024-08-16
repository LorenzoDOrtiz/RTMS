using RTMS.CoreBusiness;
using RTMS.Plugins.InMemory;
using RTMS.UseCases.Workouts.Interfaces;

namespace RTMS.UseCases.Workouts;
public class GetActiveWorkoutUseCase : IGetActiveWorkoutUseCase
{
    private readonly IWorkoutRepository _workoutRepository;

    public GetActiveWorkoutUseCase(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }
    public async Task<Workout> ExecuteAsync()
    {
        var activeWorkout = await _workoutRepository.GetActiveWorkoutAsync();

        return activeWorkout;
    }
}
