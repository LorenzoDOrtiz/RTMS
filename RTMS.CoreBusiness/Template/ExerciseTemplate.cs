using System.ComponentModel.DataAnnotations;

namespace RTMS.CoreBusiness.Template;

public class ExerciseTemplate
{
    public int Id { get; set; }

    public int WorkoutTemplateId { get; set; }

    [Required(ErrorMessage = "Exercise name is required.")]
    public string Name { get; set; }

    public int RestTimeBetweenSets { get; set; }

    public bool IsRestTimerOpen { get; set; } = false;

    public int RestTimerValue { get; set; } = 0;

    public string RestTimerUnit { get; set; } = "minutes";

    public List<ExerciseTemplateSet>? Sets { get; set; } = new(); // Collection of sets for the exercise

    public string Note { get; set; } = string.Empty;
}
