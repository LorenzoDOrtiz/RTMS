using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;

namespace RTMS.Plugins.InMemory;
public class WorkoutRepository : IWorkoutRepository
{
    private List<WorkoutTemplate> _workouts;
    public WorkoutRepository()
    {
        _workouts = new List<WorkoutTemplate>
        {
            new WorkoutTemplate {
                UserId = 1,
                Id = 1,
                Name = "Workout ZZZZ",
                Exercises = new List<ExerciseTemplate>()
                {
                    new ExerciseTemplate { Id = 2, Name = "Flat Bench Press", DefaultReps = 10, DefaultSets = 3, DefaultWeight = 225, Note = "Shoulder blades up, back, and down." }
                }
            }
        };
    }

    public Task AddWorkoutAsync(WorkoutTemplate workout)
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
            exercise.WorkoutTemplateId = workout.Id;
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

    public Task<WorkoutTemplate> GetWorkoutAsync(int id)
    {
        // userId is set to 1 for now until identity is added.
        var userWorkouts = GetWorkoutsByUserIdAsync(1).Result.ToList();
        return Task.FromResult(userWorkouts.First(w => w.Id == id));
    }

    public Task<IEnumerable<WorkoutTemplate>> GetWorkoutsByUserIdAsync(int userId)
    {
        return Task.FromResult(_workouts.Where(x => x.UserId == userId));
    }

    public Task UpdateWorkoutAsync(WorkoutTemplate workout)
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
                    existingExercise.DefaultSets = incomingExercise.DefaultSets;
                    existingExercise.DefaultReps = incomingExercise.DefaultReps;
                    existingExercise.DefaultWeight = incomingExercise.DefaultWeight;
                    existingExercise.Note = incomingExercise.Note;
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