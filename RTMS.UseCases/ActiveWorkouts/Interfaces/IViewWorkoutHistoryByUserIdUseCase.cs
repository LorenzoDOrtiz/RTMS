using RTMS.CoreBusiness.Active;

namespace RTMS.UseCases.ActiveWorkouts.Interfaces;
public interface IViewWorkoutHistoryByUserIdUseCase
{
    Task<List<Workout>> ExecuteAsync(int userId);
}