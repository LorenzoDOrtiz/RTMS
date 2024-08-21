using RTMS.CoreBusiness.Active;
using RTMS.CoreBusiness.Template;
using RTMS.Plugins.InMemory;
using RTMS.UseCases.Workouts.Interfaces;

namespace RTMS.UseCases.Workouts
{
    public class AddWorkoutUseCase : IAddWorkoutUseCase
    {
        private readonly IWorkoutRepository _workoutRepository;

        public AddWorkoutUseCase(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

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

            await _workoutRepository.AddWorkoutAsync(workout);

            return workout;
        }
    }
}
