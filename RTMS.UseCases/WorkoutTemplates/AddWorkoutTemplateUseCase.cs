using Microsoft.EntityFrameworkCore;
using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.WorkoutTemplates.Interfaces;

namespace RTMS.UseCases.WorkoutTemplates;
public class AddWorkoutTemplateUseCase(IWorkoutTemplateRepository workoutRepository) : IAddWorkoutTemplateUseCase
{
    public async Task ExecuteAsync(WorkoutTemplate workoutTemplate)
    {
        if (workoutTemplate == null)
        {
            throw new ArgumentNullException(nameof(workoutTemplate), "Workout Template cannot be null.");
        }

        try
        {
            workoutTemplate.CreatedAt = DateTime.UtcNow;
            await workoutRepository.AddWorkoutTemplateAsync(workoutTemplate);
        }
        catch (DbUpdateException ex)
        {
            // Handle specific database update exception
            throw new DbUpdateException("An error occurred while adding the workout template to the database.", ex);
        }
    }
}