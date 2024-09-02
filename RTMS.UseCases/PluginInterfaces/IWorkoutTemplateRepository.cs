using RTMS.CoreBusiness.WorkoutTemplate;

namespace RTMS.UseCases.PluginInterfaces;
public interface IWorkoutTemplateRepository
{
    Task AddWorkoutTemplateAsync(WorkoutTemplate workoutTemplate);
    Task DeleteWorkoutTemplateAsync(int id);
    Task<WorkoutTemplate> GetWorkoutTemplateByIdAsync(int id);
    Task<List<WorkoutTemplate>> GetWorkoutTemplatesByUserIdAsync(Guid userId);
    Task UpdateWorkoutTemplateAsync(WorkoutTemplate workoutTemplate);
}