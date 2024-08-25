using RTMS.CoreBusiness.Active;

namespace RTMS.Plugins.InMemory;

public class WorkoutRepository : IWorkoutRepository
{
    private readonly List<Workout> _workouts = new();

    public Task AddWorkoutAsync(Workout workout)
    {
        // Generate a new Id for the workout
        workout.Id = _workouts.Any() ? _workouts.Max(w => w.Id) + 1 : 1;

        // Store the workout
        _workouts.Add(workout);

        return Task.CompletedTask;
    }

    public Task<Workout> GetWorkoutByIdAsync(int workoutId)
    {
        var workout = _workouts.FirstOrDefault(w => w.Id == workoutId);
        return Task.FromResult(workout);
    }

    public Task EndWorkoutAsync(int workoutId)
    {
        var workout = _workouts.FirstOrDefault(w => w.Id == workoutId);
        if (workout != null)
        {
            workout.EndTime = DateTime.Now;  // Mark the end time
            workout.IsCompleted = true;      // Mark the workout as completed
        }

        return Task.CompletedTask;
    }

    public Task<List<Workout>> ViewWorkoutHistoryByUserIdAsync(int userId)
    {
        var userWorkouts = _workouts.Where(w => w.UserId == userId).ToList();

        return Task.FromResult(userWorkouts);
    }
}