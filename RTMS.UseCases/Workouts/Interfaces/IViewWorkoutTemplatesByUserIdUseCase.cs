using RTMS.CoreBusiness;

namespace RTMS.UseCases.Workouts.Interfaces;
public interface IViewWorkoutTemplatesByUserIdUseCase
{
    Task<IEnumerable<WorkoutTemplate>> ExecuteAsync(int userId);
}