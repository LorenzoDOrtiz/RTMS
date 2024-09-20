using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.WorkoutTemplates.Interfaces;

namespace RTMS.UseCases.WorkoutTemplates
{
    public class AddClientWorkoutTemplateUseCase(IWorkoutTemplateRepository workoutTemplateRepository) : IAddClientWorkoutTemplateUseCase
    {
        public async Task ExecuteAsync(ClientWorkoutTemplate clientWorkoutTemplate)
        {
            await workoutTemplateRepository.AddClientWorkoutTemplateAsync(clientWorkoutTemplate);
        }
    }
}
