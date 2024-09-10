using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RTMS.CoreBusiness;
public class Workout
{
    [Key]
    public int Id { get; set; }  // Primary key

    [Required]
    public Guid UserId { get; set; } // Link to ASP.NET Core Identity User
    public User User { get; set; }

    [Required]
    public string Name { get; set; }  // Name of the workout

    [Required]
    public DateTime StartTime { get; set; }  // Timestamp when the workout started

    public DateTime? EndTime { get; set; }  // Timestamp when the workout ended

    [ForeignKey("TemplateId")]
    public int TemplateId { get; set; }  // Foreign key to WorkoutTemplate

    public virtual WorkoutTemplate Template { get; set; }  // Navigation property

    public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();  // Collection of exercises in the workout

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