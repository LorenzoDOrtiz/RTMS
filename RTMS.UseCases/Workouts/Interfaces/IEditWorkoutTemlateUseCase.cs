using RTMS.CoreBusiness;

namespace RTMS.UseCases.Workouts.Interfaces;
public interface IEditWorkoutTemlateUseCase
{
    Task ExecuteAsync(WorkoutTemplate workout);
}