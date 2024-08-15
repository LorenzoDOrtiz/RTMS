using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.WorkoutTemplates.Interfaces;

namespace RTMS.UseCases.WorkoutTemplates;
public class AddWorkoutTemplateUseCase : IAddWorkoutTemplateUseCase
{
    private readonly IWorkoutTemplateRepository _workoutRepository;

    public AddWorkoutTemplateUseCase(IWorkoutTemplateRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }
    public async Task ExecuteAsync(WorkoutTemplate workout)
    {
        await _workoutRepository.AddWorkoutTemplateAsync(workout);
    }
}