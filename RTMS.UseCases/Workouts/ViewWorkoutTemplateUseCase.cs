using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Workouts.Interfaces;

namespace RTMS.UseCases.Workouts;
public class ViewWorkoutTemplateUseCase : IViewWorkoutTemplateUseCase
{
    private readonly IWorkoutRepository _workoutRepository;

    public ViewWorkoutTemplateUseCase(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public async Task<WorkoutTemplate> ExecuteAsync(int id)
    {
        return await _workoutRepository.GetWorkoutAsync(id);
    }
}