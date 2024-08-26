namespace RTMS.CoreBusiness.Template;

public class ExerciseTemplateSet
{
    public int Id { get; set; }

    public int ExerciseTemplateId { get; set; }

    public int Reps { get; set; }

    public double Weight { get; set; }
    public ExerciseTemplate ExerciseTemplate { get; set; }
}
