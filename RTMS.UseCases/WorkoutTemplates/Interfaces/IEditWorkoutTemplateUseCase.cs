using RTMS.CoreBusiness.WorkoutTemplate;

namespace RTMS.UseCases.WorkoutTemplates.Interfaces;
public interface IEditWorkoutTemplateUseCase
{
    Task ExecuteAsync(WorkoutTemplate workout);
}