using RTMS.CoreBusiness.Active;
using RTMS.UseCases.PluginInterfaces;

namespace RTMS.Plugins.SqlServer;
public class ActiveWorkoutRepositorySqlServer : IActiveWorkoutRepository
{
    public Task AddWorkoutAsync(Workout workout)
    {
        throw new NotImplementedException();
    }

    public Task EndWorkoutAsync(int workoutId)
    {
        throw new NotImplementedException();
    }

    public Task<Workout> GetWorkoutByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
