namespace RTMS.Web.ViewModels.WorkoutTemplate;

public class WorkoutTemplateViewModel
{
    public Guid UserId { get; set; }

    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public List<ExerciseTemplateViewModel>? Exercises { get; set; }
}