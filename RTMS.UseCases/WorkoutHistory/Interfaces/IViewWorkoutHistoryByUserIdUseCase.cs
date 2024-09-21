using RTMS.CoreBusiness;

namespace RTMS.UseCases.WorkoutHistory.Interfaces;
public interface IViewWorkoutHistoryByUserIdUseCase
{
    Task<List<Workout>> ExecuteAsync(Guid userId);
}