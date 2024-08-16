using RTMS.CoreBusiness.Active;

namespace RTMS.UseCases.Workouts.Interfaces;
public interface IGetActiveWorkoutUseCase
{
    Task<Workout> ExecuteAsync();
}