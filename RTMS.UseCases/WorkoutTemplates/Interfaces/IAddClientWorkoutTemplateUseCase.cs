using RTMS.CoreBusiness;

namespace RTMS.UseCases.WorkoutTemplates.Interfaces;
public interface IAddClientWorkoutTemplateUseCase
{
    Task ExecuteAsync(ClientWorkoutTemplate clientWorkoutTemplate);
}