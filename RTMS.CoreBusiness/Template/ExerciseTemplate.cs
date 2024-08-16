using System.ComponentModel.DataAnnotations;

namespace RTMS.CoreBusiness.Template;
public class ExerciseTemplate
{
    public int Id { get; set; }
    public int WorkoutTemplateId { get; set; }

    [Required(ErrorMessage = "Exercise name is required.")]
    public string Name { get; set; }
    public List<ExerciseTemplateSet>? Sets { get; set; } = new(); // Collection of sets for the exercise

    public string Note { get; set; } = string.Empty;
}
