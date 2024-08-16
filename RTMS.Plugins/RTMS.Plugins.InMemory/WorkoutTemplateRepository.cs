﻿using RTMS.CoreBusiness.Template;
using RTMS.UseCases.PluginInterfaces;

namespace RTMS.Plugins.InMemory;
public class WorkoutTemplateRepository : IWorkoutTemplateRepository
{
    private List<WorkoutTemplate> _workoutTemplates;
    public WorkoutTemplateRepository()
    {
        _workoutTemplates = new List<WorkoutTemplate>
    {
        new WorkoutTemplate
        {
            UserId = 1,
            Id = 1,
            Name = "Workout A",
            Exercises = new List<ExerciseTemplate>
            {
                new ExerciseTemplate
                {
                    Id = 11,
                    Name = "Barbell Flat Bench Press",
                    Sets = new List<ExerciseTemplateSet>
                    {
                        new ExerciseTemplateSet { Reps = 10, Weight = 225 },
                        new ExerciseTemplateSet { Reps = 10, Weight = 225 },
                        new ExerciseTemplateSet { Reps = 10, Weight = 225 }
                    },
                    Note = "Shoulder blades up, back, and down."
                },
                new ExerciseTemplate
                {
                    Id = 12,
                    Name = "Barbell Incline Bench Press",
                    Sets = new List<ExerciseTemplateSet>
                    {
                        new ExerciseTemplateSet { Reps = 10, Weight = 185 },
                        new ExerciseTemplateSet { Reps = 10, Weight = 185 },
                        new ExerciseTemplateSet { Reps = 10, Weight = 185 }
                    },
                    Note = "Shoulder blades up, back, and down."
                }
            }
        },
        new WorkoutTemplate
        {
            UserId = 1,
            Id = 2,
            Name = "Workout B",
            Exercises = new List<ExerciseTemplate>
            {
                new ExerciseTemplate
                {
                    Id = 21,
                    Name = "Barbell Dead Lift",
                    Sets = new List<ExerciseTemplateSet>
                    {
                        new ExerciseTemplateSet { Reps = 10, Weight = 425 },
                        new ExerciseTemplateSet { Reps = 10, Weight = 425 },
                        new ExerciseTemplateSet { Reps = 10, Weight = 425 }
                    },
                    Note = "Feet shoulder width apart."
                },
                new ExerciseTemplate
                {
                    Id = 22,
                    Name = "Barbell Squats",
                    Sets = new List<ExerciseTemplateSet>
                    {
                        new ExerciseTemplateSet { Reps = 10, Weight = 385 },
                        new ExerciseTemplateSet { Reps = 10, Weight = 385 },
                        new ExerciseTemplateSet { Reps = 10, Weight = 385 }
                    },
                    Note = "Watch for butt wink."
                }
            }
        }
    };
    }

    public Task AddWorkoutTemplateAsync(WorkoutTemplate workout)
    {
        // Get the maxId
        var maxId = _workoutTemplates.Max(x => x.Id);

        // Increment
        workout.Id = maxId + 1;

        // Set UserId to 1 until Identity is added
        workout.UserId = 1;

        // Set the Workout Id in each exercise to the passed in Workout Id
        foreach (var exercise in workout.Exercises)
        {
            exercise.WorkoutTemplateId = workout.Id;
        }

        // Add to in memory "table"
        _workoutTemplates.Add(workout);

        return Task.CompletedTask;
    }

    public Task DeleteWorkoutTemplateAsync(int workoutId)
    {
        var workoutToDelete = _workoutTemplates.First(x => x.Id == workoutId);
        _workoutTemplates.Remove(workoutToDelete);
        return Task.CompletedTask;
    }

    public Task<WorkoutTemplate> GetWorkoutTemplateAsync(int id)
    {
        // userId is set to 1 for now until identity is added.
        var userWorkouts = GetWorkoutsByUserIdAsync(1).Result.ToList();
        return Task.FromResult(userWorkouts.First(w => w.Id == id));
    }

    public Task<IEnumerable<WorkoutTemplate>> GetWorkoutsByUserIdAsync(int userId)
    {
        return Task.FromResult(_workoutTemplates.Where(x => x.UserId == userId));
    }

    public Task UpdateWorkoutTemplateAsync(WorkoutTemplate workout)
    {
        var workoutToUpdate = _workoutTemplates.FirstOrDefault(x => x.Id == workout.Id);

        if (workoutToUpdate is not null)
        {
            workoutToUpdate.Name = workout.Name;

            // Update the exercises
            foreach (var updatedExercise in workout.Exercises)
            {
                var existingExercise = workoutToUpdate.Exercises.FirstOrDefault(e => e.Id == updatedExercise.Id);

                if (existingExercise is not null)
                {
                    existingExercise.Name = updatedExercise.Name;
                    existingExercise.Sets = updatedExercise.Sets;
                    existingExercise.Note = updatedExercise.Note;
                }
                else
                {
                    // This is a new exercise, add it to the workout
                    workoutToUpdate.Exercises.Add(updatedExercise);
                }
            }

            // Remove exercises that are no longer in the incoming workout
            workoutToUpdate.Exercises.RemoveAll(e => !workout.Exercises.Any(updatedE => updatedE.Id == e.Id));
        }
        return Task.CompletedTask;
    }
}