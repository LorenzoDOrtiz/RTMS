using RTMS.CoreBusiness.Active;
using RTMS.CoreBusiness.WorkoutTemplate;

namespace RTMS.UseCases.Workouts.Interfaces;
public interface IAddActiveWorkoutUseCase
{
    Task<Workout> ExecuteAsync(WorkoutTemplate workoutTemplate);
}