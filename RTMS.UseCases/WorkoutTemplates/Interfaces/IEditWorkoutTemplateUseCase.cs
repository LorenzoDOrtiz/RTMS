using RTMS.CoreBusiness;

namespace RTMS.UseCases.WorkoutTemplates.Interfaces;
public interface IEditWorkoutTemplateUseCase
{
    Task<WorkoutTemplate> ExecuteAsync(WorkoutTemplate workout);
}