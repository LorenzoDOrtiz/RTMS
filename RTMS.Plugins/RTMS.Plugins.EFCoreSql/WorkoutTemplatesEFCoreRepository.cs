using Microsoft.EntityFrameworkCore;
using RTMS.CoreBusiness.Template;
using RTMS.UseCases.PluginInterfaces;

namespace RTMS.Plugins.EFCoreSql;
public class WorkoutTemplatesEFCoreRepository : IWorkoutTemplateRepository
{
    private readonly IDbContextFactory<RTMSContext> _contextFactory;

    public WorkoutTemplatesEFCoreRepository(IDbContextFactory<RTMSContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task AddWorkoutTemplateAsync(WorkoutTemplate workout)
    {
        using var db = _contextFactory.CreateDbContext();

        db.WorkoutTemplates?.Add(workout);

        foreach (var exercise in workout.Exercises)
        {
            db.ExerciseTemplates?.Add(exercise);

            foreach (var set in exercise.Sets)
            {
                db.ExerciseTemplateSets?.Add(set);
            }
        }

        await db.SaveChangesAsync();
    }

    public async Task DeleteWorkoutTemplateAsync(WorkoutTemplate workout)
    {
        using var db = _contextFactory.CreateDbContext();

        db.WorkoutTemplates?.Remove(workout);

        await db.SaveChangesAsync();
    }

    public async Task<IEnumerable<WorkoutTemplate>> GetWorkoutsByUserIdAsync(int userId)
    {
        using var db = _contextFactory.CreateDbContext();

        // Query the database for workout templates associated with the specified userId
        var workouts = await db.WorkoutTemplates
            .Where(w => w.UserId == userId)
            .Include(w => w.Exercises) // Include exercises to avoid lazy loading issues
            .ThenInclude(e => e.Sets) // Include sets for each exercise
            .ToListAsync();

        return workouts;
    }


    public async Task<WorkoutTemplate> GetWorkoutTemplateAsync(int id)
    {
        using var db = _contextFactory.CreateDbContext();

        // Query the database for the workout template with the specified ID
        var workoutTemplate = await db.WorkoutTemplates
            .Where(w => w.Id == id)
            .Include(w => w.Exercises) // Include exercises to avoid lazy loading issues
            .ThenInclude(e => e.Sets) // Include sets for each exercise
            .FirstOrDefaultAsync(); // Use FirstOrDefault to get a single result or null

        return workoutTemplate;
    }


    public async Task UpdateWorkoutTemplateAsync(WorkoutTemplate workout)
    {
        using var db = _contextFactory.CreateDbContext();

        // Attach the workout template to the context if it's not already tracked
        db.WorkoutTemplates.Attach(workout);

        // Mark the entity as modified
        db.Entry(workout).State = EntityState.Modified;

        // Ensure related entities (exercises and sets) are tracked and updated as well
        foreach (var exercise in workout.Exercises)
        {
            db.ExerciseTemplates.Attach(exercise);
            db.Entry(exercise).State = EntityState.Modified;

            foreach (var set in exercise.Sets)
            {
                db.ExerciseTemplateSets.Attach(set);
                db.Entry(set).State = EntityState.Modified;
            }
        }

        // Save all changes to the database
        await db.SaveChangesAsync();
    }

}
