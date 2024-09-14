using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Workouts.Interfaces;

namespace RTMS.UseCases.Workouts
{
    public class AddWorkoutUseCase(IWorkoutHistoryRepository workoutRepository) : IAddWorkoutUseCase
    {
        public async Task<int> ExecuteAsync(Workout workout)
        {
            var workoutId = await workoutRepository.AddWorkoutAsync(workout);

            return workoutId;
        }

        public async Task SaveWorkoutProgressAsync(Workout workout)
        {
            // Save ongoing workout state (mark as incomplete)
            workout.IsCompleted = false;
            await workoutRepository.UpdateWorkoutAsync(workout);
        }

    }
}
