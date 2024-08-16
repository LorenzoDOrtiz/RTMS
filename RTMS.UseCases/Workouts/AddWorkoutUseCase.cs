using RTMS.CoreBusiness.Active;
using RTMS.CoreBusiness.Template;
using RTMS.Plugins.InMemory;
using RTMS.UseCases.Workouts.Interfaces;

namespace RTMS.UseCases.Workouts;
public class AddWorkoutUseCase : IAddWorkoutUseCase
{
    private readonly IWorkoutRepository _workoutRepository;

    public AddWorkoutUseCase(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    public async Task ExecuteAsync(WorkoutTemplate workoutTemplate)
    {
        var workout = new Workout
        {
            Name = workoutTemplate.Name,
            TemplateId = workoutTemplate.Id,
            StartTime = DateTime.Now,  // Set the start time when the workout begins
            Exercises = workoutTemplate.Exercises.Select(e => new Exercise
            {
                Name = e.Name,
                Note = e.Note,
                Sets = e.Sets.Select(s => new ExerciseSet
                {
                    Reps = s.Reps,
                    Weight = s.Weight
                }).ToList()
            }).ToList()
        };

        // Store the workout in the repository
        await _workoutRepository.AddWorkoutAsync(workout);
    }
}
