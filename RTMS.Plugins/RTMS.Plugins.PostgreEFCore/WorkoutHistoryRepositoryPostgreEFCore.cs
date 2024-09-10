using Microsoft.EntityFrameworkCore;
using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;

namespace RTMS.Plugins.PostgreEFCore;
public class WorkoutHistoryRepositoryPostgreEFCore(IDbContextFactory<RTMSDBContext> contextFactory) : IWorkoutHistoryRepository
{
    public async Task AddWorkoutAsync(Workout workout)
    {
        using var context = contextFactory.CreateDbContext();
        await context.AddAsync(workout);
        await context.SaveChangesAsync();
    }

    public async Task EndWorkoutAsync(Workout workout)
    {
        using var context = contextFactory.CreateDbContext();
        var workoutToEnd = await context.Workouts.FindAsync(workout.Id);

        if (workoutToEnd != null)
        {
            workoutToEnd.IsCompleted = true;
            workoutToEnd.EndTime = DateTime.Now;
            await context.SaveChangesAsync();
        }
    }

    public async Task UpdateWorkoutAsync(Workout workout)
    {
        using var context = contextFactory.CreateDbContext();
        context.Workouts.Update(workout);
        await context.SaveChangesAsync();
    }

    public async Task<Workout> ViewActiveWorkoutByUserIdAsync(Guid userId)
    {
        using var context = contextFactory.CreateDbContext();
        return await context.Workouts.FirstOrDefaultAsync(w => w.UserId == userId && !w.IsCompleted);

    }

    public async Task<List<Workout>> ViewWorkoutHistoryByUserIdAsync(Guid userId)
    {
        using var context = contextFactory.CreateDbContext();

        return await context.Workouts.Where(w => w.UserId == userId && w.IsCompleted == true).ToListAsync();
    }
}
