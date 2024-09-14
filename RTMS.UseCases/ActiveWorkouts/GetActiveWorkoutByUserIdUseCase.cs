using RTMS.CoreBusiness;
using RTMS.UseCases.ActiveWorkouts.Interfaces;
using RTMS.UseCases.PluginInterfaces;

namespace RTMS.UseCases.ActiveWorkouts;
public class GetActiveWorkoutByUserIdUseCase(IWorkoutHistoryRepository workoutHistoryRepository) : IGetActiveWorkoutByUserIdUseCase
{
    Task<Workout> IGetActiveWorkoutByUserIdUseCase.ExecuteAsync(Guid userId)
    {
        return workoutHistoryRepository.GetActiveWorkoutIdByUserId(userId);
    }
}
