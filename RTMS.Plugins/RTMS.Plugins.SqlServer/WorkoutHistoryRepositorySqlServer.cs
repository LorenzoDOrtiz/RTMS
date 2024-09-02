using RTMS.CoreBusiness.Active;
using RTMS.UseCases.PluginInterfaces;

namespace RTMS.Plugins.SqlServer;
public class WorkoutHistoryRepositorySqlServer : IWorkoutHistoryRepository
{
    public Task<List<Workout>> ViewWorkoutHistoryByUserIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }
}
