using RTMS.CoreBusiness;

namespace RTMS.UseCases.WorkoutHistory.Interfaces;
public interface IGetDetailedWorkoutHistoryByTemplateIdUseCase
{
    Task<IEnumerable<Workout>> ExecuteAsync(int templateId);
}