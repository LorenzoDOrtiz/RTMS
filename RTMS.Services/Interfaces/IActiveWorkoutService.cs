using RTMS.CoreBusiness.Active;
using RTMS.CoreBusiness.WorkoutTemplate;

namespace RTMS.Services.Interfaces;

public interface IActiveWorkoutService
{
    public bool WorkoutIsActive(Guid userId);
    public string GetActiveWorkoutName(Guid userId);
    Task SaveActiveWorkoutAsync(Workout workout);
    Task<Workout?> GetActiveWorkoutAsync(Guid userId);
    Task StartWorkoutAsync(Guid userId, WorkoutTemplate workoutTemplate);
}