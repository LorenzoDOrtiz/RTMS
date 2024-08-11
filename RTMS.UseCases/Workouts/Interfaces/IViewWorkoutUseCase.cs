using RTMS.CoreBusiness;

namespace RTMS.UseCases.Workouts.Interfaces;
public interface IViewWorkoutUseCase
{
    Task<Workout> ExecuteAsync(int id);
}