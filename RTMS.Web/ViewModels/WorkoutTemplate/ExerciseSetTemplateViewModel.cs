namespace RTMS.Web.ViewModels.WorkoutTemplate;

public class ExerciseSetTemplateViewModel
{
    public int ExerciseTemplateId { get; set; }

    public int Id { get; set; }

    public int Reps { get; set; } = 10;

    public double Weight { get; set; } = 0;
}