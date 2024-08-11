using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Workouts.Interfaces;

namespace RTMS.UseCases.Workouts;
public class ViewWorkoutsByUserIdUseCase : IViewWorkoutsByUserIdUseCase
{
    private readonly IWorkoutRepository _workoutRepository;

    public ViewWorkoutsByUserIdUseCase(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public async Task<IEnumerable<Workout>> ExecuteAsync(int userId)
    {
        return await _workoutRepository.GetWorkoutsByUserIdAsync(userId);
    }
}
