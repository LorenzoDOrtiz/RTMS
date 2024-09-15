using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Workouts;

namespace RTMS.UseCases.ActiveWorkouts;

public class EndWorkoutUseCase(IWorkoutHistoryRepository workoutRepository) : IEndWorkoutUseCase
{
    public async Task ExecuteAsync(Workout workout)
    {
        workout.EndTime = DateTime.UtcNow;
        workout.IsCompleted = true;

        await workoutRepository.UpdateWorkoutAsync(workout);
    }
}