namespace RTMS.CoreBusiness.WorkoutTemplate;

public class WorkoutTemplate
{
    public Guid UserId { get; set; }

    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public List<ExerciseTemplate>? Exercises { get; set; }
}