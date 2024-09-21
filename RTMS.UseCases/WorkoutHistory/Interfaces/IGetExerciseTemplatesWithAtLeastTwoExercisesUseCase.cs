using RTMS.CoreBusiness;

namespace RTMS.UseCases.WorkoutHistory.Interfaces;
public interface IGetExerciseTemplatesWithAtLeastTwoExercisesUseCase
{
    Task<IEnumerable<ExerciseTemplate>> ExecuteAsync(Guid userId);
}