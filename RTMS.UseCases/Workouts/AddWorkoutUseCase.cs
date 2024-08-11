using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Workouts.Interfaces;

namespace RTMS.UseCases.Workouts;
public class AddWorkoutUseCase : IAddWorkoutUseCase
{
    private readonly IWorkoutRepository _workoutRepository;

    public AddWorkoutUseCase(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }
    public async Task ExecuteAsync(Workout workout)
    {
        await _workoutRepository.AddWorkoutAsync(workout);
    }
}