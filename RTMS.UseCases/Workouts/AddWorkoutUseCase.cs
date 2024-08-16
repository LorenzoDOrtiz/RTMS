using RTMS.CoreBusiness;
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
            StartTime = DateTime.Now,  // Set the start time when workout begins
            Exercises = workoutTemplate.Exercises.Select(e => new Exercise
            {
                Name = e.Name,
                Note = e.Note,
                Sets = Enumerable.Range(0, e.DefaultSets).Select(_ => new ExerciseSet
                {
                    Reps = e.DefaultReps,
                    Weight = e.DefaultWeight
                }).ToList()
            }).ToList()
        };

        // Store the workout in the repository
        await _workoutRepository.AddWorkoutAsync(workout);
    }
}
