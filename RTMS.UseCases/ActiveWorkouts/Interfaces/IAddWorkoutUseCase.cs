using RTMS.CoreBusiness;

namespace RTMS.UseCases.Workouts.Interfaces;
public interface IAddWorkoutUseCase
{
    Task<int> ExecuteAsync(Workout workout);

    Task SaveWorkoutProgressAsync(Workout workout);
}