using RTMS.CoreBusiness;

namespace RTMS.UseCases.WorkoutHistory.Interfaces;
public interface IGetDetailedExerciseHistoryByTemplateIdUseCase
{
    Task<IEnumerable<Exercise>> ExecuteAsync(int templateId);
}