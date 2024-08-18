using System.ComponentModel.DataAnnotations;

namespace RTMS.CoreBusiness.Template;

public class ExerciseTemplateSet
{
    public int Id { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Reps must be at least 1.")]
    public int Reps { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Weight must be non-negative.")]
    public double Weight { get; set; }
}
