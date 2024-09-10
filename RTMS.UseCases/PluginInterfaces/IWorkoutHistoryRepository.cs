using RTMS.CoreBusiness;

namespace RTMS.UseCases.PluginInterfaces;
public interface IWorkoutHistoryRepository
{
    Task AddWorkoutAsync(Workout workout);
    Task UpdateWorkoutAsync(Workout workout);
    Task EndWorkoutAsync(Workout workout);
    Task<Workout> ViewActiveWorkoutByUserIdAsync(Guid userId);
    Task<List<Workout>> ViewWorkoutHistoryByUserIdAsync(Guid userId);
}