using System.ComponentModel.DataAnnotations;

namespace RTMS.CoreBusiness;

public class ExerciseSetTemplate
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ExerciseTemplateId { get; set; }

    [Required]
    public int Reps { get; set; }

    [Required]
    public double Weight { get; set; }
}
