namespace RTMS.Web.ViewModels;

public class WorkoutTemplateViewModel
{
    public string UserId { get; set; }

    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public List<ExerciseTemplateViewModel>? Exercises { get; set; }
}