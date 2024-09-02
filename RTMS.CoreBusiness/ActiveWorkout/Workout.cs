using RTMS.CoreBusiness.Template;

namespace RTMS.CoreBusiness.Active;
public class Workout
{
    public int Id { get; set; }  // Unique identifier for the workout

    public Guid UserId { get; set; } // Link to ASP.NET Core Identity User

    public int TemplateId { get; set; }  // Reference to the WorkoutTemplate it was created from

    public WorkoutTemplate Template { get; set; }

    public string Name { get; set; }  // Name of the workout (usually copied from the template)

    public DateTime StartTime { get; set; }  // Timestamp when the workout started

    public DateTime? EndTime { get; set; }  // Timestamp when the workout ended

    public TimeSpan Duration => EndTime.HasValue ? EndTime.Value - StartTime : TimeSpan.Zero;  // Calculate the duration

    public List<Exercise> Exercises { get; set; } = new();  // List of exercises in the workout

    public double GetTotalWorkoutVolume()
    {
        double totalVolume = 0;

        foreach (var exercise in Exercises)
        {
            foreach (var set in exercise.Sets)
            {
                totalVolume += set.Reps * set.Weight;
            }
        }

        return totalVolume;
    }

    public bool IsCompleted { get; set; }  // Flag to indicate if the workout is completed
}