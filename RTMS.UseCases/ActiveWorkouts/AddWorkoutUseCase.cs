using Microsoft.EntityFrameworkCore;
using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Workouts.Interfaces;

namespace RTMS.UseCases.Workouts
{
    public class AddWorkoutUseCase(IWorkoutHistoryRepository workoutRepository) : IAddWorkoutUseCase
    {
        public async Task<int> ExecuteAsync(Workout workout)
        {
            if (workout == null)
            {
                throw new ArgumentNullException(nameof(workout), "Workout cannot be null.");
            }
            try
            {
                var workoutId = await workoutRepository.AddWorkoutAsync(workout);
                return workoutId;
            }
            catch (DbUpdateException ex)
            {
                // Handle specific database update exception
                throw new DbUpdateException("An error occurred while adding the workout to the database.", ex);
            }
        }

        public async Task SaveWorkoutProgressAsync(Workout workout)
        {
            // Save ongoing workout state (mark as incomplete)
            workout.IsCompleted = false;
            await workoutRepository.UpdateWorkoutAsync(workout);
        }

    }
}
