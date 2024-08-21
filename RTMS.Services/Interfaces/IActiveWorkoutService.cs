using RTMS.CoreBusiness.Active;
using RTMS.CoreBusiness.Template;

namespace RTMS.Services.Interfaces;

public interface IActiveWorkoutService
{
    public bool WorkoutIsActive(int userId);
    public string GetActiveWorkoutName(int userId);
    Task EndWorkoutAsync(int userId);
    Task<Workout?> GetActiveWorkoutAsync(int userId);
    Task StartWorkoutAsync(int userId, WorkoutTemplate workoutTemplate);
}