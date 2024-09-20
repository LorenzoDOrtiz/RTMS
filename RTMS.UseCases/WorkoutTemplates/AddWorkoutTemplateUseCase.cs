﻿using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.WorkoutTemplates.Interfaces;

namespace RTMS.UseCases.WorkoutTemplates;
public class AddWorkoutTemplateUseCase(IWorkoutTemplateRepository workoutRepository) : IAddWorkoutTemplateUseCase
{
    public async Task ExecuteAsync(WorkoutTemplate workoutTemplate)
    {
        workoutTemplate.CreatedAt = DateTime.UtcNow;
        await workoutRepository.AddWorkoutTemplateAsync(workoutTemplate);
    }
}