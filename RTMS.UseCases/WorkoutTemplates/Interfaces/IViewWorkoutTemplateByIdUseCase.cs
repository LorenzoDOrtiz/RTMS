using RTMS.CoreBusiness;

namespace RTMS.UseCases.WorkoutTemplates.Interfaces;
public interface IViewWorkoutTemplateByIdUseCase
{
    Task<WorkoutTemplate> ExecuteAsync(int id);
}