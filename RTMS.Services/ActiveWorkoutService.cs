using RTMS.CoreBusiness.Active;
using RTMS.CoreBusiness.WorkoutTemplate;
using RTMS.Services.Interfaces;
using RTMS.UseCases.Workouts;
using RTMS.UseCases.Workouts.Interfaces;

namespace RTMS.Services;

public class ActiveWorkoutService(IAddActiveWorkoutUseCase addWorkoutUseCase,
    IEndActiveWorkoutUseCase endWorkoutUseCase) : IActiveWorkoutService
{
    private readonly Dictionary<Guid, Workout> _userWorkouts = new();

    public bool WorkoutIsActive(Guid userId) => _userWorkouts.ContainsKey(userId);

    public string GetActiveWorkoutName(Guid userId) => _userWorkouts.TryGetValue(userId, out var workout) ? workout.Name : string.Empty;

    public async Task StartWorkoutAsync(Guid userId, WorkoutTemplate workoutTemplate)
    {
        var workout = await addWorkoutUseCase.ExecuteAsync(workoutTemplate);
        _userWorkouts[userId] = workout;
    }

    public async Task SaveActiveWorkoutAsync(Workout workout)
    {
        await endWorkoutUseCase.ExecuteAsync(workout.Id);
        _userWorkouts.Remove(workout.UserId);
    }

    public Task<Workout?> GetActiveWorkoutAsync(Guid userId)
    {
        _userWorkouts.TryGetValue(userId, out var workout);
        return Task.FromResult(workout);
    }
}