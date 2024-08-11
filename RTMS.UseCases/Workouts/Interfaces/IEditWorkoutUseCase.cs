using RTMS.CoreBusiness;

namespace RTMS.UseCases.Workouts.Interfaces;
public interface IEditWorkoutUseCase
{
    Task ExecuteAsync(Workout workout);
}