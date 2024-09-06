using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RTMS.CoreBusiness;
public class Exercise
{
    [Key]
    public int Id { get; set; }  // Primary key

    [Required]
    public string Name { get; set; }  // Name of the exercise

    [ForeignKey("WorkoutId")]
    public int WorkoutId { get; set; }  // Foreign key to Workout

    public virtual Workout Workout { get; set; }  // Navigation property

    public int RestTimerValue { get; set; } = 0;

    public string RestTimerUnit { get; set; } = "minutes";

    public int RestTimerSecondsBetweenSets
    {
        get
        {
            return RestTimerUnit switch
            {
                "minutes" => RestTimerValue * 60,
                "seconds" => RestTimerValue,
                _ => 0, // Default or handle other units if necessary
            };
        }
    }

    public virtual ICollection<ExerciseSet> Sets { get; set; } = new List<ExerciseSet>(); // Collection of sets for the exercise

    public string? Note { get; set; }
}