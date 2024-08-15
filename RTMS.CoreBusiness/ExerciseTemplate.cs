using System.ComponentModel.DataAnnotations;

namespace RTMS.CoreBusiness;
public class ExerciseTemplate
{
    public int Id { get; set; }
    public int WorkoutTemplateId { get; set; }

    [Required(ErrorMessage = "Exercise name is required.")]
    public string Name { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Sets must be at least 1.")]
    public int DefaultSets { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Reps must be at least 1.")]
    public int DefaultReps { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Weight must be non-negative.")]
    public double DefaultWeight { get; set; }

    public string Note { get; set; } = string.Empty;
}
