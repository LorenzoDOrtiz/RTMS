using RTMS.CoreBusiness.Active;
using RTMS.CoreBusiness.Template;

namespace RTMS.UseCases.Workouts.Interfaces;
public interface IAddActiveWorkoutUseCase
{
    Task<Workout> ExecuteAsync(WorkoutTemplate workoutTemplate);
}