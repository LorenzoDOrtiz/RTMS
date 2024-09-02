using RTMS.CoreBusiness.WorkoutTemplate;

namespace RTMS.UseCases.WorkoutTemplates.Interfaces;
public interface IViewWorkoutTemplatesByUserIdUseCase
{
    Task<IEnumerable<WorkoutTemplate>> ExecuteAsync(Guid userId);
}