using RTMS.CoreBusiness;

namespace RTMS.UseCases.Workouts.Interfaces;
public interface IViewWorkoutsByUserIdUseCase
{
    Task<IEnumerable<Workout>> ExecuteAsync(int userId);
}