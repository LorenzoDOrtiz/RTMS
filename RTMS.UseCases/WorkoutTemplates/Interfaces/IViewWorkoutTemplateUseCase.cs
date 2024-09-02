using RTMS.CoreBusiness.WorkoutTemplate;

namespace RTMS.UseCases.WorkoutTemplates.Interfaces;
public interface IViewWorkoutTemplateUseCase
{
    Task<WorkoutTemplate> ExecuteAsync(int id);
}