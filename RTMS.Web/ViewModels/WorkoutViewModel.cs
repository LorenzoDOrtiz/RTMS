﻿namespace RTMS.Web.ViewModels;

public class WorkoutViewModel
{
    public int Id { get; set; }  // Unique identifier for the workout

    public Guid UserId { get; set; } // Link to ASP.NET Core Identity User

    public int WorkoutTemplateId { get; set; }  // Reference to the WorkoutTemplate it was created from

    public string Name { get; set; }  // Name of the workout (usually copied from the template)

    public DateTime StartTime { get; set; }  // Timestamp when the workout started

    public DateTime? EndTime { get; set; }  // Timestamp when the workout ended

    public TimeSpan Duration => EndTime.HasValue ? EndTime.Value - StartTime : TimeSpan.Zero;  // Calculate the duration

    public List<ExerciseViewModel> Exercises { get; set; } = new(); // List of exercises in the workout

    public bool IsCompleted { get; set; }  // Flag to indicate if the workout is completed

    public bool ShowDetails { get; set; }
}
