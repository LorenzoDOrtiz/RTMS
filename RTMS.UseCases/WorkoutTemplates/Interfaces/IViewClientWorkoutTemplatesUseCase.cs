using RTMS.CoreBusiness;

namespace RTMS.UseCases.WorkoutTemplates.Interfaces;
public interface IViewClientWorkoutTemplatesUseCase
{
    Task<List<WorkoutTemplate>> ExecuteAsync(Guid clientId);
}