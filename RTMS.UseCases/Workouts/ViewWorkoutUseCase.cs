using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Workouts.Interfaces;

namespace RTMS.UseCases.Workouts;
public class ViewWorkoutUseCase : IViewWorkoutUseCase
{
    private readonly IWorkoutRepository _workoutRepository;

    public ViewWorkoutUseCase(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public async Task<Workout> ExecuteAsync(int id)
    {
        return await _workoutRepository.GetWorkoutAsync(id);
    }
}