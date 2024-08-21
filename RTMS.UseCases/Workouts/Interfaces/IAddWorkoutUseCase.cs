using RTMS.CoreBusiness.Active;
using RTMS.CoreBusiness.Template;

namespace RTMS.UseCases.Workouts.Interfaces;
public interface IAddWorkoutUseCase
{
    Task<Workout> ExecuteAsync(WorkoutTemplate workoutTemplate);
}