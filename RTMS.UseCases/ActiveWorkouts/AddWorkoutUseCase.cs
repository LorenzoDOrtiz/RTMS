using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Workouts.Interfaces;

namespace RTMS.UseCases.Workouts
{
    public class AddWorkoutUseCase(IWorkoutHistoryRepository workoutRepository) : IAddWorkoutUseCase
    {
        public async Task<Workout> ExecuteAsync(WorkoutTemplate workoutTemplate)
        {
            var workout = new Workout
            {
                UserId = workoutTemplate.UserId,
                Name = workoutTemplate.Name,
                TemplateId = workoutTemplate.Id,
                StartTime = DateTime.Now,
                Exercises = workoutTemplate.Exercises.Select(e => new Exercise
                {
                    Name = e.Name,
                    Note = e.Note,
                    RestTimerUnit = e.RestTimerUnit,
                    RestTimerValue = e.RestTimerValue,
                    Sets = e.Sets.Select(s => new ExerciseSet
                    {
                        Reps = s.Reps,
                        Weight = s.Weight
                    }).ToList()
                }).ToList()
            };

            await workoutRepository.AddWorkoutAsync(workout);

            return workout;
        }
    }
}
