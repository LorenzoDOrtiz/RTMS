using System.ComponentModel.DataAnnotations;

namespace RTMS.CoreBusiness;

public class ExerciseTemplate : BaseEntity
{

    [Required]
    public int WorkoutTemplateId { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public int RestTimerValue { get; set; } = 0;

    public string RestTimerUnit { get; set; } = "minutes";

    public ICollection<ExerciseSetTemplate> Sets { get; set; } = new List<ExerciseSetTemplate>();

    public string? Note { get; set; }
}
