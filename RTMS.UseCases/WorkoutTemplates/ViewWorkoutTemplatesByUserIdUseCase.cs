using RTMS.CoreBusiness.Template;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.WorkoutTemplates.Interfaces;

namespace RTMS.UseCases.WorkoutTemplates;
public class ViewWorkoutTemplatesByUserIdUseCase : IViewWorkoutTemplatesByUserIdUseCase
{
    private readonly IWorkoutTemplateRepository _workoutRepository;

    public ViewWorkoutTemplatesByUserIdUseCase(IWorkoutTemplateRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public async Task<IEnumerable<WorkoutTemplate>> ExecuteAsync(int userId)
    {
        return await _workoutRepository.GetWorkoutsByUserIdAsync(userId);
    }
}
