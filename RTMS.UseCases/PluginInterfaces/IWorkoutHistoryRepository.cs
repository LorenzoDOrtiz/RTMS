using RTMS.CoreBusiness;

namespace RTMS.UseCases.PluginInterfaces;
public interface IWorkoutHistoryRepository
{
    Task<int> AddWorkoutAsync(Workout workout);
    Task UpdateWorkoutAsync(Workout workout);
    Task<Workout> ViewActiveWorkoutByWorkoutAndUserIdAsync(int workoutId, Guid userId);
    Task<List<Workout>> ViewWorkoutHistoryByUserIdAsync(Guid userId);
    Task<Workout> GetActiveWorkoutIdByUserId(Guid userId);
    Task<Workout> GetDetailedWorkoutHistoryByWorkoutIdAsync(int workoutId);
    Task<IEnumerable<Workout>> GetDetailedWorkoutHistoryByTemplateIdAsync(int templateId);
    Task<IEnumerable<Exercise>> GetDetailedExerciseHistoryByTemplateId(int templateId);
    Task<List<Workout>> GetAllDetailedWorkoutDataByUserIdAsync(Guid userId);
    Task<IEnumerable<Exercise>> GetExercisesbyUserIdAsync(Guid userId);
}