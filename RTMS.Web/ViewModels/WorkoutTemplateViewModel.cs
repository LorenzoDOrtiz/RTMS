namespace RTMS.Web.ViewModels;

public class WorkoutTemplateViewModel
{
    public int Id { get; set; }
    public int UserId { get; set; } // Link to ASP.NET Core Identity User
    public string Name { get; set; }
    public List<ExerciseTemplateViewModel> Exercises { get; set; }
}
