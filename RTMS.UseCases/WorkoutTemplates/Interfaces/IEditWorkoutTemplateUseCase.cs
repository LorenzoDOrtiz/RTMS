using RTMS.CoreBusiness;

namespace RTMS.UseCases.WorkoutTemplates.Interfaces;
public interface IEditWorkoutTemplateUseCase
{
    Task ExecuteAsync(WorkoutTemplate workout);
}