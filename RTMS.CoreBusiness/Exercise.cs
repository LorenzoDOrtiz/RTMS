namespace RTMS.CoreBusiness;
public class Exercise
{
    public int Id { get; set; }
    public int WorkoutId { get; set; }
    public string Name { get; set; }
    public int Sets { get; set; }
    public int Reps { get; set; }
    public double Weight { get; set; }
    public string Notes { get; set; }
}
