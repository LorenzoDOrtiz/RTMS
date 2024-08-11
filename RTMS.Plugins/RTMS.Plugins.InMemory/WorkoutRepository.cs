using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;

namespace RTMS.Plugins.InMemory;
public class WorkoutRepository : IWorkoutRepository
{
    private List<Workout> _workouts;
    public WorkoutRepository()
    {
        _workouts = new List<Workout>
        {
            new Workout {
                UserId = 1,
                Id = 1,
                Name = "Workout ZZZZ",
                Exercises = new List<Exercise>()
                {
                    new Exercise { Id = 2, Name = "Flat Bench Press", Reps = 10, Sets = 3, Weight = 225, Notes = "Shoulder blades up, back, and down." }
                }
            }
        };
    }

    public Task AddWorkoutAsync(Workout workout)
    {
        // Get the maxId
        var maxId = _workouts.Max(x => x.Id);

        // Increment
        workout.Id = maxId + 1;

        // Set UserId to 1 until Identity is added
        workout.UserId = 1;

        // Set the Workout Id in each exercise to the passed in Workout Id
        foreach (var exercise in workout.Exercises)
        {
            exercise.WorkoutId = workout.Id;
        }

        // Add to in memory "table"
        _workouts.Add(workout);

        return Task.CompletedTask;
    }

    public Task DeleteWorkoutAsync(int workoutId)
    {
        var workoutToDelete = _workouts.First(x => x.Id == workoutId);
        _workouts.Remove(workoutToDelete);
        return Task.CompletedTask;
    }

    public Task<Workout> GetWorkoutAsync(int id)
    {
        var userWorkouts = GetWorkoutsByUserIdAsync(id).Result.ToList();
        return Task.FromResult(userWorkouts.First(w => w.Id == id));
    }

    public Task<IEnumerable<Workout>> GetWorkoutsByUserIdAsync(int userId)
    {
        return Task.FromResult(_workouts.Where(x => x.UserId == userId));
    }

    public Task UpdateWorkoutAsync(Workout workout)
    {
        var workoutToUpdate = _workouts.FirstOrDefault(x => x.Id == workout.Id);
        if (workoutToUpdate is not null)
        {
            workoutToUpdate.Name = workout.Name;
            // Update the exercises
            foreach (var exercise in workoutToUpdate.Exercises)
            {
                var exerciseToUpdate = workout.Exercises.FirstOrDefault(e => e.Id == exercise.Id);
                if (exerciseToUpdate is not null)
                {
                    exerciseToUpdate.Name = exercise.Name;
                    exerciseToUpdate.Sets = exercise.Sets;
                    exerciseToUpdate.Reps = exercise.Reps;
                    exerciseToUpdate.Weight = exercise.Weight;
                    exerciseToUpdate.Notes = exercise.Notes;
                }
            }
        }
        return Task.CompletedTask;
    }
}