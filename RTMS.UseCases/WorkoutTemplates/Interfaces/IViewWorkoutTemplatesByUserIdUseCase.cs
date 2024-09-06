using RTMS.CoreBusiness;

namespace RTMS.UseCases.WorkoutTemplates.Interfaces;
public interface IViewWorkoutTemplatesByUserIdUseCase
{
    Task<IEnumerable<WorkoutTemplate>> ExecuteAsync(string userId);
}