using Microsoft.EntityFrameworkCore;
using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;

namespace RTMS.Plugins.PostgreEFCore;
public class WorkoutHistoryRepositoryPostgreEFCore(IDbContextFactory<RTMSDBContext> contextFactory) : IWorkoutHistoryRepository
{
    public async Task<int> AddWorkoutAsync(Workout workout)
    {
        using var context = contextFactory.CreateDbContext();
        var newWorkout = await context.AddAsync(workout);
        await context.SaveChangesAsync();
        return workout.Id;
    }

    public async Task UpdateWorkoutAsync(Workout workout)
    {
        using var context = contextFactory.CreateDbContext();

        // Load the existing workout with related entities
        var existingWorkout = await context.Workouts
            .Include(w => w.Exercises)
                .ThenInclude(e => e.Sets)
            .SingleOrDefaultAsync(w => w.Id == workout.Id);

        if (existingWorkout != null)
        {
            // Update properties of the existing workout
            context.Entry(existingWorkout).CurrentValues.SetValues(workout);

            // Compare existing exercises with new exercises
            var existingExercises = existingWorkout.Exercises.ToList();
            var newExercises = workout.Exercises.ToList();

            // Find exercises to remove
            var exercisesToRemove = existingExercises
                .Where(e => !newExercises.Any(ne => ne.Id == e.Id))
                .ToList();
            context.Exercises.RemoveRange(exercisesToRemove);

            // Find exercises to update or add
            foreach (var newExercise in newExercises)
            {
                var existingExercise = existingExercises.SingleOrDefault(e => e.Id == newExercise.Id);
                if (existingExercise != null)
                {
                    // Update existing exercise
                    context.Entry(existingExercise).CurrentValues.SetValues(newExercise);

                    // Compare existing sets with new sets
                    var existingSets = existingExercise.Sets.ToList();
                    var newSets = newExercise.Sets.ToList();

                    // Find sets to remove
                    var setsToRemove = existingSets
                        .Where(s => !newSets.Any(ns => ns.Id == s.Id))
                        .ToList();
                    context.ExerciseSets.RemoveRange(setsToRemove);

                    // Find sets to add or update
                    foreach (var newSet in newSets)
                    {
                        var existingSet = existingSets.SingleOrDefault(s => s.Id == newSet.Id);
                        if (existingSet != null)
                        {
                            // Update existing set
                            context.Entry(existingSet).CurrentValues.SetValues(newSet);
                        }
                        else
                        {
                            // Add new set
                            existingExercise.Sets.Add(newSet);
                        }
                    }
                }
                else
                {
                    // Add new exercise
                    existingWorkout.Exercises.Add(newExercise);
                }
            }

            await context.SaveChangesAsync();
        }
    }


    // this just gets the workout table, not the whole workout
    // used for the workout in progress button in the mainlayout and to check
    // if there's a in progress workout for a template before starting another one
    public async Task<Workout> GetActiveWorkoutIdByUserId(Guid userId)
    {
        using var context = contextFactory.CreateDbContext();
        var workout = await context.Workouts
            .FirstOrDefaultAsync(w => w.IsCompleted == false && w.UserId == userId);
        return workout;
    }

    public async Task<Workout> ViewActiveWorkoutByWorkoutAndUserIdAsync(int workoutId, Guid userId)
    {
        using var context = contextFactory.CreateDbContext();
        var workout = await context.Workouts
            .Include(w => w.Exercises)
            .ThenInclude(e => e.Sets)
            .FirstOrDefaultAsync(w => w.Id == workoutId && w.UserId == userId);
        return workout;
    }

    public async Task<List<Workout>> ViewWorkoutHistoryByUserIdAsync(Guid userId)
    {
        using var context = contextFactory.CreateDbContext();

        return await context.Workouts.Where(w => w.UserId == userId && w.IsCompleted == true).ToListAsync();
    }

    public async Task<Workout> GetDetailedWorkoutHistoryByWorkoutIdAsync(int workoutId)
    {
        using var context = contextFactory.CreateDbContext();
        var workout = await context.Workouts
            .Include(w => w.Exercises)
            .ThenInclude(e => e.Sets)
            .FirstOrDefaultAsync(w => w.Id == workoutId);

        return workout;
    }

    public async Task<IEnumerable<Workout>> GetDetailedWorkoutHistoryByTemplateIdAsync(int templateId)
    {
        using var context = contextFactory.CreateDbContext();

        var workouts = await context.Workouts
            .Include(w => w.Exercises)
            .ThenInclude(e => e.Sets)
            .Where(w => w.WorkoutTemplateId == templateId)
            .ToListAsync();

        return workouts;
    }

    public async Task<IEnumerable<Exercise>> GetDetailedExerciseHistoryByTemplateId(int templateId)
    {
        using var context = contextFactory.CreateDbContext();

        var exercises = await context.Exercises
            .Include(e => e.Sets)
            .Include(e => e.Workout) // including the workout to get the time for the exercise volume chart
            .Where(e => e.ExerciseTemplateId == templateId)
            .ToListAsync();

        return exercises;
    }

    public async Task<List<Workout>> GetAllDetailedWorkoutDataByUserIdAsync(Guid userId)
    {
        using var context = contextFactory.CreateDbContext();

        return await context.Workouts
            .Include(w => w.Exercises)
                .ThenInclude(e => e.Sets)
            .Where(w => w.UserId == userId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Exercise>> GetExercisesbyUserIdAsync(Guid userId)
    {
        using var context = contextFactory.CreateDbContext();

        // Fetch distinct exercises associated with the specified userId through workouts
        var exercises = await context.Workouts
            .Where(workout => workout.UserId == userId) // Filter workouts by userId
            .SelectMany(workout => workout.Exercises) // Flatten exercises from the workouts
            .Distinct() // Get distinct exercises
            .ToListAsync();

        return exercises;
    }
}
