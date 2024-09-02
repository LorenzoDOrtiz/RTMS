using RTMS.CoreBusiness.Active;

namespace RTMS.UseCases.PluginInterfaces;
public interface IWorkoutHistoryRepository
{
    Task<List<Workout>> ViewWorkoutHistoryByUserIdAsync(Guid userId);
}