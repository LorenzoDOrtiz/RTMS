using RTMS.CoreBusiness;

namespace RTMS.UseCases.WorkoutTemplates.Interfaces;
public interface IEditWorkoutTemlateUseCase
{
    Task ExecuteAsync(WorkoutTemplate workout);
}