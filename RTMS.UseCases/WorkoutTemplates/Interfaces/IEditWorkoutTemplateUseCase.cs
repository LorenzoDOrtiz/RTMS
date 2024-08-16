using RTMS.CoreBusiness.Template;

namespace RTMS.UseCases.WorkoutTemplates.Interfaces;
public interface IEditWorkoutTemplateUseCase
{
    Task ExecuteAsync(WorkoutTemplate workout);
}