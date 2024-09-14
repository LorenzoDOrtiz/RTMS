using RTMS.CoreBusiness;

namespace RTMS.UseCases.ActiveWorkouts.Interfaces;
public interface IGetActiveWorkoutByUserIdUseCase
{
    Task<Workout> ExecuteAsync(Guid userId);
}