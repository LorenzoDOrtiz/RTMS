using RTMS.CoreBusiness;

namespace RTMS.UseCases.PluginInterfaces;
public interface IWorkoutTemplateRepository
{
    Task AddWorkoutTemplateAsync(WorkoutTemplate workoutTemplate);
    Task DeleteWorkoutTemplateAsync(int templateId);
    Task<WorkoutTemplate> GetWorkoutTemplateByIdAsync(int templateId);
    Task<List<WorkoutTemplate>> GetWorkoutTemplatesByUserIdAsync(Guid userId);
    Task UpdateWorkoutTemplateAsync(WorkoutTemplate workoutTemplate);
}