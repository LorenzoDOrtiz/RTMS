﻿using Microsoft.EntityFrameworkCore;
using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;

namespace RTMS.Plugins.PostgreEFCore;
public class WorkoutTemplateRepositoryPostgreEFCore(IDbContextFactory<RTMSDBContext> contextFactory) : IWorkoutTemplateRepository
{
    public async Task AddWorkoutTemplateAsync(WorkoutTemplate workoutTemplate)
    {
        using var context = contextFactory.CreateDbContext();
        await context.AddAsync(workoutTemplate);
        await context.SaveChangesAsync();
    }

    public async Task AddClientWorkoutTemplateAsync(ClientWorkoutTemplate clientWorkoutTemplate)
    {
        using var context = contextFactory.CreateDbContext();
        await context.AddAsync(clientWorkoutTemplate);
        await context.SaveChangesAsync();
    }

    public async Task RemoveTrainerTemplateFromClientAsync(int workoutTemplateId, Guid clientId)
    {
        using var context = contextFactory.CreateDbContext();

        var clientWorkoutTemplate = await context.ClientWorkoutTemplates
            .FirstOrDefaultAsync(cwt => cwt.WorkoutTemplateId == workoutTemplateId && cwt.ClientId == clientId);  // You need to pass the clientId

        if (clientWorkoutTemplate != null)
        {
            context.ClientWorkoutTemplates.Remove(clientWorkoutTemplate);
            await context.SaveChangesAsync();
        }
    }

    public async Task DeleteWorkoutTemplateAsync(int templateId)
    {
        using var context = contextFactory.CreateDbContext();
        var workoutTemplate = await context.WorkoutTemplates.FindAsync(templateId);

        if (workoutTemplate != null)
        {
            context.WorkoutTemplates.Remove(workoutTemplate);
            await context.SaveChangesAsync();
        }
    }

    public async Task<WorkoutTemplate> GetWorkoutTemplateByIdAsync(int templateId)
    {
        using var context = contextFactory.CreateDbContext();
        return await context.WorkoutTemplates.Include(wt => wt.Exercises).ThenInclude(te => te.Sets).FirstOrDefaultAsync(wt => wt.Id == templateId);
    }

    public async Task<List<WorkoutTemplate>> GetWorkoutTemplatesByUserIdAsync(Guid userId)
    {
        using var context = contextFactory.CreateDbContext();

        // Get workout templates assigned to the client
        var assignedTemplates = await context.ClientWorkoutTemplates
            .Where(cwt => cwt.ClientId == userId)
            .Include(cwt => cwt.WorkoutTemplate)
                .ThenInclude(wt => wt.Exercises)
                    .ThenInclude(e => e.Sets)
            .Include(cwt => cwt.WorkoutTemplate.User) // Include User information
            .Select(cwt => cwt.WorkoutTemplate)
            .ToListAsync();

        // Get workout templates created by the user
        var createdTemplates = await context.WorkoutTemplates
            .Where(wt => wt.UserId == userId)
            .Include(wt => wt.Exercises)
                .ThenInclude(e => e.Sets)
            .Include(wt => wt.User) // Include User information
            .ToListAsync();

        // Combine the two lists
        var allTemplates = assignedTemplates.Concat(createdTemplates).ToList();

        return allTemplates;
    }


    public async Task<List<WorkoutTemplate>> ViewClientWorkoutTemplatesAsync(Guid clientId)
    {
        using var context = contextFactory.CreateDbContext();

        // Get workouts assigned to the client via the join table
        return await context.ClientWorkoutTemplates
            .Where(cwt => cwt.ClientId == clientId)
            .Include(cwt => cwt.WorkoutTemplate)
            .ThenInclude(wt => wt.User)
            .Select(cwt => cwt.WorkoutTemplate)
            .ToListAsync();
    }

    // EF core doesn't track changes in exercise or sets since we go to and from view models so we have to do this monstrosity
    public async Task UpdateWorkoutTemplateAsync(WorkoutTemplate workoutTemplate)
    {
        using var context = contextFactory.CreateDbContext();

        // Load the existing workout template with related entities
        var existingTemplate = await context.WorkoutTemplates
            .Include(wt => wt.Exercises)
                .ThenInclude(e => e.Sets)
            .SingleOrDefaultAsync(wt => wt.Id == workoutTemplate.Id);

        if (existingTemplate != null)
        {
            // Update properties of the existing template
            context.Entry(existingTemplate).CurrentValues.SetValues(workoutTemplate);

            // Compare existing exercises with new exercises
            var existingExercises = existingTemplate.Exercises.ToList();
            var newExercises = workoutTemplate.Exercises.ToList();

            // Find exercises to remove
            var exercisesToRemove = existingExercises
                .Where(e => !newExercises.Any(ne => ne.Id == e.Id))
                .ToList();
            context.ExerciseTemplates.RemoveRange(exercisesToRemove);

            // Find exercises to update or add
            foreach (var newExercise in newExercises)
            {
                var existingExercise = existingExercises.SingleOrDefault(e => e.Id == newExercise.Id);
                if (existingExercise != null)
                {
                    // Update existing exercise
                    context.Entry(existingExercise).CurrentValues.SetValues(newExercise);

                    // Compare existing sets with new sets
                    var existingSets = existingExercise.Sets.ToList();
                    var newSets = newExercise.Sets.ToList();

                    // Find sets to remove
                    var setsToRemove = existingSets
                        .Where(s => !newSets.Any(ns => ns.Id == s.Id))
                        .ToList();
                    context.ExerciseSetTemplates.RemoveRange(setsToRemove);

                    // Find sets to add or update
                    foreach (var newSet in newSets)
                    {
                        var existingSet = existingSets.SingleOrDefault(s => s.Id == newSet.Id);
                        if (existingSet != null)
                        {
                            // Update existing set
                            context.Entry(existingSet).CurrentValues.SetValues(newSet);
                        }
                        else
                        {
                            // Add new set
                            existingExercise.Sets.Add(newSet);
                        }
                    }
                }
                else
                {
                    // Add new exercise
                    existingTemplate.Exercises.Add(newExercise);
                }
            }

            // Update workout history to reflect the new template name
            var completedWorkouts = await context.Workouts
                .Where(w => w.WorkoutTemplateId == workoutTemplate.Id)
                .ToListAsync();

            foreach (var workout in completedWorkouts)
            {
                workout.Name = workoutTemplate.Name; // Sync workout name with updated template name
            }

            await context.SaveChangesAsync();
        }
    }
}
