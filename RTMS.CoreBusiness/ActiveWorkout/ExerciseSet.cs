namespace RTMS.CoreBusiness.Active;
public class ExerciseSet
{
    public int Id { get; set; }

    public int ExerciseId { get; set; }

    public int Reps { get; set; }

    public double Weight { get; set; }

    public Exercise Exercise { get; set; }

}