using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.WorkoutTemplates.Interfaces;

namespace RTMS.UseCases.WorkoutTemplates;
public class EditWorkoutTemlateUseCase : IEditWorkoutTemlateUseCase
{
    private readonly IWorkoutTemplateRepository _workoutRepository;

    public EditWorkoutTemlateUseCase(IWorkoutTemplateRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public async Task ExecuteAsync(WorkoutTemplate workout)
    {
        await _workoutRepository.UpdateWorkoutTemplateAsync(workout);
    }
}
