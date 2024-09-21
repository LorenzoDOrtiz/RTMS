using RTMS.CoreBusiness;

namespace RTMS.UseCases.WorkoutTemplates.Interfaces;
public interface IGetWorkoutTemplatesWithAtLeastTwoWorkoutsUseCase
{
    Task<IEnumerable<WorkoutTemplate>> ExecuteAsync(Guid userId);
}