using RTMS.CoreBusiness;

namespace RTMS.UseCases.PluginInterfaces;
public interface IWorkoutTemplateRepository
{
    Task AddClientWorkoutTemplateAsync(ClientWorkoutTemplate clientWorkoutTemplate);
    Task AddWorkoutTemplateAsync(WorkoutTemplate workoutTemplate);
    Task DeleteWorkoutTemplateAsync(int templateId);
    Task<List<ExerciseTemplate>> GetExerciseTemplatesWithAtLeastTwoExercisesAsync(Guid userId);
    Task<WorkoutTemplate> GetWorkoutTemplateByIdAsync(int templateId);
    Task<List<WorkoutTemplate>> GetWorkoutTemplatesByUserIdAsync(Guid userId);
    Task<List<WorkoutTemplate>> GetWorkoutTemplatesWithAtLeastTwoWorkoutsAsync(Guid userId);
    Task RemoveTrainerTemplateFromClientAsync(int workoutTemplateId, Guid clientId);
    Task<WorkoutTemplate> UpdateWorkoutTemplateAsync(WorkoutTemplate workoutTemplate);
    Task<List<WorkoutTemplate>> ViewClientWorkoutTemplatesAsync(Guid clientId);
}