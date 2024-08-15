using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Workouts.Interfaces;

namespace RTMS.UseCases.Workouts;
public class ViewWorkoutTemplatesByUserIdUseCase : IViewWorkoutTemplatesByUserIdUseCase
{
    private readonly IWorkoutRepository _workoutRepository;

    public ViewWorkoutTemplatesByUserIdUseCase(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public async Task<IEnumerable<WorkoutTemplate>> ExecuteAsync(int userId)
    {
        return await _workoutRepository.GetWorkoutsByUserIdAsync(userId);
    }
}
