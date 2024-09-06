using RTMS.CoreBusiness;

namespace RTMS.UseCases.ActiveWorkouts.Interfaces;
public interface IViewWorkoutHistoryByUserIdUseCase
{
    Task<List<Workout>> ExecuteAsync(string userId);
}