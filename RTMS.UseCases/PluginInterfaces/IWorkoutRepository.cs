using RTMS.CoreBusiness;

namespace RTMS.UseCases.PluginInterfaces;

public interface IWorkoutRepository
{
    Task AddWorkoutAsync(Workout workout);
    Task DeleteWorkoutAsync(int workoutId);
    Task<Workout> GetWorkoutAsync(int Id);
    Task<IEnumerable<Workout>> GetWorkoutsByUserIdAsync(int userId);
    Task UpdateWorkoutAsync(Workout workout);
}