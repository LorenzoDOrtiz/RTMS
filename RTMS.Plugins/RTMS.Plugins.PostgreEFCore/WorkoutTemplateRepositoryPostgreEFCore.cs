using Microsoft.EntityFrameworkCore;
using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;

namespace RTMS.Plugins.PostgreEFCore;
public class WorkoutTemplateRepositoryPostgreEFCore(IDbContextFactory<RTMSDBContext> contextFactory) : IWorkoutTemplateRepository
{
    public async Task AddWorkoutTemplateAsync(WorkoutTemplate workoutTemplate)
    {
        using var context = contextFactory.CreateDbContext();
        await context.AddAsync(workoutTemplate);
        await context.SaveChangesAsync();
    }

    public async Task DeleteWorkoutTemplateAsync(int templateId)
    {
        using var context = contextFactory.CreateDbContext();
        var workoutTemplate = await context.WorkoutTemplates.FindAsync(templateId);

        if (workoutTemplate != null)
        {
            context.WorkoutTemplates.Remove(workoutTemplate);
            await context.SaveChangesAsync();
        }
    }

    public async Task<WorkoutTemplate> GetWorkoutTemplateByIdAsync(int templateId)
    {
        using var context = contextFactory.CreateDbContext();
        return await context.WorkoutTemplates.FindAsync(templateId);
    }

    public async Task<List<WorkoutTemplate>> GetWorkoutTemplatesByUserIdAsync(Guid userId)
    {
        using var context = contextFactory.CreateDbContext();

        return await context.WorkoutTemplates.Where(w => w.UserId == userId).ToListAsync();
    }

    public async Task UpdateWorkoutTemplateAsync(WorkoutTemplate workoutTemplate)
    {
        using var context = contextFactory.CreateDbContext();
        context.WorkoutTemplates.Update(workoutTemplate);
        await context.SaveChangesAsync();
    }
}
