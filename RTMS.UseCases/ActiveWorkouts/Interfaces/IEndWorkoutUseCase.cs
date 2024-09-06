using RTMS.CoreBusiness;

namespace RTMS.UseCases.Workouts;

public interface IEndWorkoutUseCase
{
    Task ExecuteAsync(Workout workout);
}