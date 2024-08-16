using RTMS.CoreBusiness.Template;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.WorkoutTemplates.Interfaces;

namespace RTMS.UseCases.WorkoutTemplates;
public class EditWorkoutTemplateUseCase : IEditWorkoutTemplateUseCase
{
    private readonly IWorkoutTemplateRepository _workoutRepository;

    public EditWorkoutTemplateUseCase(IWorkoutTemplateRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public async Task ExecuteAsync(WorkoutTemplate workout)
    {
        await _workoutRepository.UpdateWorkoutTemplateAsync(workout);
    }
}
