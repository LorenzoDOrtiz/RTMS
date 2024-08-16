using System.ComponentModel.DataAnnotations;

namespace RTMS.CoreBusiness;
public class Exercise
{
    public int Id { get; set; }
    public int WorkoutId { get; set; } // Link to the Workout

    [Required]
    public string Name { get; set; }

    [Required, Range(1, int.MaxValue)]
    public List<ExerciseSet> Sets { get; set; } = new(); // Collection of sets for the exercise

    public string Note { get; set; } = string.Empty;
}
