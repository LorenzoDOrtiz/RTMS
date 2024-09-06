using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;

namespace RTMS.Plugins.PostgreEFCore;
public class WorkoutHistoryRepositoryPostgreEFCore : IWorkoutHistoryRepository
{
    public Task AddWorkoutAsync(Workout workout)
    {
        throw new NotImplementedException();
    }

    public Task EndWorkoutAsync(Workout workout)
    {
        throw new NotImplementedException();
    }

    public Task UpdateWorkoutAsync(Workout workout)
    {
        throw new NotImplementedException();
    }

    public Task<Workout> ViewActiveWorkoutByUserIdAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Workout>> ViewWorkoutHistoryByUserIdAsync(string userId)
    {
        throw new NotImplementedException();
    }
}
