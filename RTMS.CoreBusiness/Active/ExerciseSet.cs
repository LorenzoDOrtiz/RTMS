namespace RTMS.CoreBusiness.Active;
public class ExerciseSet
{
    public int Id { get; set; }

    public int Reps { get; set; }

    public double Weight { get; set; }

    public int InitialRestTime { get; set; } // Keep this if it’s part of business logic
}