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
        // userId is set to 1 for now until identity is added.
        var userWorkouts = GetWorkoutsByUserIdAsync(1).Result.ToList();
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
            foreach (var incomingExercise in workout.Exercises)
            {
                var existingExercise = workoutToUpdate.Exercises.FirstOrDefault(e => e.Id == incomingExercise.Id);
                if (existingExercise is not null)
                {
                    existingExercise.Name = incomingExercise.Name;
                    existingExercise.Sets = incomingExercise.Sets;
                    existingExercise.Reps = incomingExercise.Reps;
                    existingExercise.Weight = incomingExercise.Weight;
                    existingExercise.Notes = incomingExercise.Notes;
                }
                else
                {
                    // This is a new exercise, add it to the workout
                    workoutToUpdate.Exercises.Add(incomingExercise);
                }
            }
            // Remove exercises that are no longer in the incoming workout
            workoutToUpdate.Exercises.RemoveAll(e => !workout.Exercises.Any(incomingE => incomingE.Id == e.Id));
        }
        return Task.CompletedTask;
    }
}