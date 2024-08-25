using RTMS.CoreBusiness.Active;

namespace RTMS.Plugins.InMemory;

public interface IWorkoutRepository
{
    Task AddWorkoutAsync(Workout workout);
    Task<Workout> GetWorkoutByIdAsync(int id);
    Task EndWorkoutAsync(int workoutId);
    Task<List<Workout>> ViewWorkoutHistoryByUserIdAsync(int userId);
}