using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.WorkoutHistory.Interfaces;

namespace RTMS.UseCases.WorkoutHistory
{
    public class GetExercisesByUserIdUseCase(IWorkoutHistoryRepository workoutHistoryRepository) : IGetExercisesByUserIdUseCase
    {
        public async Task<IEnumerable<Exercise>> ExecuteAsync(Guid UserId)
        {
            return await workoutHistoryRepository.GetExercisesbyUserIdAsync(UserId);
        }
    }
}
