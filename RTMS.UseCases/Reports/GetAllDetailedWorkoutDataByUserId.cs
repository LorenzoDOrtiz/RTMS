using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Reports.Interfaces;

namespace RTMS.UseCases.Reports;
public class GetAllDetailedWorkoutDataByUserId(IWorkoutHistoryRepository workoutHistoryRepository) : IGetAllDetailedWorkoutDataByUserId
{
    public async Task<List<Workout>> ExecuteAsync(Guid userId)
    {
        return await workoutHistoryRepository.GetAllDetailedWorkoutDataByUserIdAsync(userId);
    }
}
