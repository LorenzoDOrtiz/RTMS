using RTMS.CoreBusiness;

namespace RTMS.UseCases.Workouts.Interfaces;

public interface IAddWorkoutTemplateUseCase
{
    Task ExecuteAsync(WorkoutTemplate workout);
}