using RTMS.CoreBusiness;

namespace RTMS.UseCases.Workouts.Interfaces;
public interface IViewWorkoutTemplateUseCase
{
    Task<WorkoutTemplate> ExecuteAsync(int id);
}