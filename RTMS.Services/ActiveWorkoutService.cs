using RTMS.CoreBusiness.Active;
using RTMS.CoreBusiness.Template;
using RTMS.Services.Interfaces;
using RTMS.UseCases.Workouts;
using RTMS.UseCases.Workouts.Interfaces;

namespace RTMS.Services;

public class ActiveWorkoutService(IAddActiveWorkoutUseCase addWorkoutUseCase,
    IEndActiveWorkoutUseCase endWorkoutUseCase) : IActiveWorkoutService
{
    private readonly Dictionary<int, Workout> _userWorkouts = new();

    public bool WorkoutIsActive(int userId) => _userWorkouts.ContainsKey(userId);

    public string GetActiveWorkoutName(int userId) => _userWorkouts.TryGetValue(userId, out var workout) ? workout.Name : string.Empty;

    public async Task StartWorkoutAsync(int userId, WorkoutTemplate workoutTemplate)
    {
        var workout = await addWorkoutUseCase.ExecuteAsync(workoutTemplate);
        _userWorkouts[userId] = workout;
    }

    public async Task SaveActiveWorkoutAsync(Workout workout)
    {
        await endWorkoutUseCase.ExecuteAsync(workout.Id);
        _userWorkouts.Remove(workout.UserId);
    }

    public Task<Workout?> GetActiveWorkoutAsync(int userId)
    {
        _userWorkouts.TryGetValue(userId, out var workout);
        return Task.FromResult(workout);
    }
}