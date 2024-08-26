using RTMS.CoreBusiness.Active;
using RTMS.CoreBusiness.Template;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Workouts.Interfaces;

namespace RTMS.UseCases.ActiveWorkouts;

public class AddActiveWorkoutUseCase : IAddActiveWorkoutUseCase
{
    private readonly IWorkoutRepository _workoutRepository;

    public AddActiveWorkoutUseCase(IWorkoutRepository workoutRepository)
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
                Id = e.Id,
                Name = e.Name,
                Note = e.Note,
                RestTimerUnit = e.RestTimerUnit,
                RestTimerValue = e.RestTimerValue,
                Sets = e.Sets.Select(s => new ExerciseSet
                {
                    Id = s.Id,
                    Reps = s.Reps,
                    Weight = s.Weight
                }).ToList()
            }).ToList()
        };

        await _workoutRepository.AddWorkoutAsync(workout);

        return workout;
    }
}
