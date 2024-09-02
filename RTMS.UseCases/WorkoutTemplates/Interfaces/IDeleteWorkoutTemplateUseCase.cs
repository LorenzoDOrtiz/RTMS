
using RTMS.CoreBusiness.Template;

namespace RTMS.UseCases.WorkoutTemplates.Interfaces;

public interface IDeleteWorkoutTemplateUseCase
{
    Task ExecuteAsync(WorkoutTemplate workout);
}