using RTMS.CoreBusiness;

namespace RTMS.UseCases.Workouts.Interfaces;
public interface IGetActiveWorkoutUseCase
{
    Task<Workout> ExecuteAsync();
}