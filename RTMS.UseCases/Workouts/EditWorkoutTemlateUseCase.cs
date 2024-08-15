using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Workouts.Interfaces;

namespace RTMS.UseCases.Workouts;
public class EditWorkoutTemlateUseCase : IEditWorkoutTemlateUseCase
{
    private readonly IWorkoutRepository _workoutRepository;

    public EditWorkoutTemlateUseCase(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public async Task ExecuteAsync(WorkoutTemplate workout)
    {
        await _workoutRepository.UpdateWorkoutAsync(workout);
    }
}
