using RTMS.CoreBusiness;

namespace RTMS.UseCases.PluginInterfaces;
public interface IWorkoutTemplateRepository
{
    Task AddClientWorkoutTemplateAsync(ClientWorkoutTemplate clientWorkoutTemplate);
    Task AddWorkoutTemplateAsync(WorkoutTemplate workoutTemplate);
    Task DeleteWorkoutTemplateAsync(int templateId);
    Task<WorkoutTemplate> GetWorkoutTemplateByIdAsync(int templateId);
    Task<List<WorkoutTemplate>> GetWorkoutTemplatesByUserIdAsync(Guid userId);
    Task RemoveTrainerTemplateFromClientAsync(int workoutTemplateId, Guid clientId);
    Task UpdateWorkoutTemplateAsync(WorkoutTemplate workoutTemplate);
    Task<List<WorkoutTemplate>> ViewClientWorkoutTemplatesAsync(Guid clientId);
}