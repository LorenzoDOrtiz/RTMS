using RTMS.CoreBusiness.Template;

namespace RTMS.UseCases.Workouts.Interfaces;
public interface IAddWorkoutUseCase
{
    Task ExecuteAsync(WorkoutTemplate workoutTemplate);
}