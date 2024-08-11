namespace RTMS.CoreBusiness;

public class Workout
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Exercise> Exercises { get; set; } = new List<Exercise>();
}