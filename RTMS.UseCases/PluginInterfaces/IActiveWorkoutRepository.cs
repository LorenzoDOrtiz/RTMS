using RTMS.CoreBusiness.Active;

namespace RTMS.UseCases.PluginInterfaces;

public interface IActiveWorkoutRepository
{
    Task AddWorkoutAsync(Workout workout);
    Task<Workout> GetWorkoutByIdAsync(int id);
    Task EndWorkoutAsync(int workoutId);
}