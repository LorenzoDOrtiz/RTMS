using RTMS.Plugins.InMemory;
using RTMS.UseCases.Workouts.Interfaces;

namespace RTMS.UseCases.Workouts;
public class ViewWorkoutByIdUseCase : IViewWorkoutByIdUseCase
{
    private readonly IWorkoutRepository _workoutRepository;

    public ViewWorkoutByIdUseCase(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public async Task ExecuteAsync(int workoutId)
    {
        await _workoutRepository.GetWorkoutByIdAsync(workoutId);
    }
}
