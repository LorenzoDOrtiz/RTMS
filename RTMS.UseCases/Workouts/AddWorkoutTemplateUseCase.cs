using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Workouts.Interfaces;

namespace RTMS.UseCases.Workouts;
public class AddWorkoutTemplateUseCase : IAddWorkoutTemplateUseCase
{
    private readonly IWorkoutRepository _workoutRepository;

    public AddWorkoutTemplateUseCase(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }
    public async Task ExecuteAsync(WorkoutTemplate workout)
    {
        await _workoutRepository.AddWorkoutAsync(workout);
    }
}