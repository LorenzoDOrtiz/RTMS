using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Workouts.Interfaces;

namespace RTMS.UseCases.Workouts;
public class EditWorkoutUseCase : IEditWorkoutUseCase
{
    private readonly IWorkoutRepository _workoutRepository;

    public EditWorkoutUseCase(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public async Task ExecuteAsync(Workout workout)
    {
        await _workoutRepository.UpdateWorkoutAsync(workout);
    }
}
