using RTMS.CoreBusiness.Active;

namespace RTMS.Plugins.InMemory;

public class WorkoutRepository : IWorkoutRepository
{
    private readonly List<Workout> _workouts = new();
    private Workout? _activeWorkout;

    public Task AddWorkoutAsync(Workout workout)
    {
        // Generate a new Id for the workout
        workout.Id = _workouts.Any() ? _workouts.Max(w => w.Id) + 1 : 1;

        // Store the workout
        _workouts.Add(workout);
        _activeWorkout = workout;

        return Task.CompletedTask;
    }

    public Task<Workout> GetWorkoutByIdAsync(int workoutId)
    {
        var workout = _workouts.FirstOrDefault(w => w.Id == workoutId);
        return Task.FromResult(workout);
    }

    public Task<Workout> GetActiveWorkoutAsync()
    {
        if (_activeWorkout is not null) return Task.FromResult(_activeWorkout);

        return (Task<Workout>)Task.CompletedTask;
    }

    public Task EndWorkoutAsync(int workoutId)
    {
        var workout = _workouts.FirstOrDefault(w => w.Id == workoutId);
        if (workout != null)
        {
            workout.EndTime = DateTime.Now;  // Mark the end time
            workout.IsCompleted = true;      // Mark the workout as completed
            _activeWorkout = null;           // Clear the active workout
        }

        return Task.CompletedTask;
    }
}