namespace RTMS.CoreBusiness.WorkoutTemplate;

public class ExerciseTemplate
{
    public int WorkoutTemplateId { get; set; }

    public int Order { get; set; }

    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int RestTimerValue { get; set; } = 0;

    public string RestTimerUnit { get; set; } = "minutes";

    public List<ExerciseSetTemplate>? Sets { get; set; } = new List<ExerciseSetTemplate>();

    public string Note { get; set; } = string.Empty;
}
