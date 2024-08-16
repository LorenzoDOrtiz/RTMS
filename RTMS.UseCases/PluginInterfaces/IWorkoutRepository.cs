using RTMS.CoreBusiness.Active;

namespace RTMS.Plugins.InMemory;

public interface IWorkoutRepository
{
    Task AddWorkoutAsync(Workout workout);
    Task<Workout> GetWorkoutByIdAsync(int id);
    Task<Workout> GetActiveWorkoutAsync();
    Task EndWorkoutAsync(int workoutId);
}