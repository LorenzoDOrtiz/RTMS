using RTMS.CoreBusiness.Active;
using RTMS.Plugins.InMemory;
using RTMS.UseCases.ActiveWorkouts.Interfaces;

namespace RTMS.UseCases.ActiveWorkouts;
public class ViewWorkoutHistoryByUserIdUseCase : IViewWorkoutHistoryByUserIdUseCase
{
    private readonly IActiveWorkoutRepository _workoutRepository;

    public ViewWorkoutHistoryByUserIdUseCase(IActiveWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }
    public async Task<List<Workout>> ExecuteAsync(Guid userId)
    {
        return await _workoutRepository.ViewWorkoutHistoryByUserIdAsync(userId);
    }
}
