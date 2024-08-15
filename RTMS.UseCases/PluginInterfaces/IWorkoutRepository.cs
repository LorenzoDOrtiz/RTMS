using RTMS.CoreBusiness;

namespace RTMS.UseCases.PluginInterfaces;

public interface IWorkoutRepository
{
    Task AddWorkoutAsync(WorkoutTemplate workout);
    Task DeleteWorkoutAsync(int workoutId);
    Task<WorkoutTemplate> GetWorkoutAsync(int Id);
    Task<IEnumerable<WorkoutTemplate>> GetWorkoutsByUserIdAsync(int userId);
    Task UpdateWorkoutAsync(WorkoutTemplate workout);
}