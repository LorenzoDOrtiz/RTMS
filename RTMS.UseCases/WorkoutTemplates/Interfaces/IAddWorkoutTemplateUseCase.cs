using RTMS.CoreBusiness.Template;

namespace RTMS.UseCases.WorkoutTemplates.Interfaces;

public interface IAddWorkoutTemplateUseCase
{
    Task ExecuteAsync(WorkoutTemplate workout);
}