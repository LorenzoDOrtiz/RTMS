using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.WorkoutTemplates.Interfaces;

namespace RTMS.UseCases.WorkoutTemplates;
public class ViewWorkoutTemplateUseCase : IViewWorkoutTemplateUseCase
{
    private readonly IWorkoutTemplateRepository _workoutRepository;

    public ViewWorkoutTemplateUseCase(IWorkoutTemplateRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public async Task<WorkoutTemplate> ExecuteAsync(int id)
    {
        return await _workoutRepository.GetWorkoutTemplateAsync(id);
    }
}