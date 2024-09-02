using RTMS.CoreBusiness.WorkoutTemplate;

namespace RTMS.UseCases.WorkoutTemplates.Interfaces;

public interface IAddWorkoutTemplateUseCase
{
    Task ExecuteAsync(WorkoutTemplate workout);
}