using RTMS.CoreBusiness;

namespace RTMS.UseCases.WorkoutHistory.Interfaces;
public interface IGetExercisesByUserIdUseCase
{
    Task<IEnumerable<Exercise>> ExecuteAsync(Guid UserId);
}