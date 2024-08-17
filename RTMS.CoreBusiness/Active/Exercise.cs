using System.ComponentModel.DataAnnotations;

namespace RTMS.CoreBusiness.Active;
public class Exercise
{
    public int Id { get; set; }
    public int WorkoutId { get; set; } // Link to the Workout

    [Required]
    public string Name { get; set; }

    [Required, Range(1, int.MaxValue)]
    public int InitialRestTimeBetweenSets { get; set; } // Total rest time for each set in seconds

    public int RemainingRestTime { get; set; } // Tracks the remaining rest time during the rest period (if needed)

    public List<ExerciseSet> Sets { get; set; } = new(); // Collection of sets for the exercise

    public string Note { get; set; } = string.Empty;
}
