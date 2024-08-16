using RTMS.CoreBusiness.Template;

namespace RTMS.UseCases.PluginInterfaces;

public interface IWorkoutTemplateRepository
{
    Task AddWorkoutTemplateAsync(WorkoutTemplate workout);
    Task DeleteWorkoutTemplateAsync(int workoutId);
    Task<WorkoutTemplate> GetWorkoutTemplateAsync(int Id);
    Task<IEnumerable<WorkoutTemplate>> GetWorkoutsByUserIdAsync(int userId);
    Task UpdateWorkoutTemplateAsync(WorkoutTemplate workout);
}