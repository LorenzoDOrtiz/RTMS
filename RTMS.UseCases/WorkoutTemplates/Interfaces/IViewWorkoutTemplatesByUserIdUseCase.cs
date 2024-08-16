using RTMS.CoreBusiness.Template;

namespace RTMS.UseCases.WorkoutTemplates.Interfaces;
public interface IViewWorkoutTemplatesByUserIdUseCase
{
    Task<IEnumerable<WorkoutTemplate>> ExecuteAsync(int userId);
}