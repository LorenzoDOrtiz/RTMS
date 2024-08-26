using RTMS.CoreBusiness.Active;
using RTMS.UseCases.ActiveWorkouts.Interfaces;
using RTMS.UseCases.PluginInterfaces;

namespace RTMS.UseCases.ActiveWorkouts;

public class ViewWorkoutHistoryByUserIdUseCase : IViewWorkoutHistoryByUserIdUseCase
{
    private readonly IWorkoutRepository _workoutRepository;

    public ViewWorkoutHistoryByUserIdUseCase(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }
    public async Task<List<Workout>> ExecuteAsync(int userId)
    {
        return await _workoutRepository.ViewWorkoutHistoryByUserIdAsync(userId);
    }
}
