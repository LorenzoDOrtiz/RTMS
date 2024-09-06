using System.ComponentModel.DataAnnotations;

namespace RTMS.CoreBusiness;

public class ExerciseTemplate
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int WorkoutTemplateId { get; set; }

    [Required]
    public int Order { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public int RestTimerValue { get; set; } = 0;

    public string RestTimerUnit { get; set; } = "minutes";

    public virtual ICollection<ExerciseSetTemplate> Sets { get; set; } = new List<ExerciseSetTemplate>();

    public string? Note { get; set; }
}
