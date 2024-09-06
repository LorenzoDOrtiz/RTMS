using RTMS.CoreBusiness;

namespace RTMS.UseCases.Workouts.Interfaces;

public interface IViewActiveWorkoutByIdUseCase
{
    Task<Workout> ExecuteAsync(string userId);
}