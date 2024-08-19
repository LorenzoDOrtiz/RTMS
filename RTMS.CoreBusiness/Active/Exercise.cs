namespace RTMS.CoreBusiness.Active;
public class Exercise
{
    public int Id { get; set; }

    public int WorkoutId { get; set; } // Link to the Workout

    public string Name { get; set; }

    public int InitialRestTimeBetweenSets { get; set; } // Total rest time for each set in seconds

    public List<ExerciseSet> Sets { get; set; } = new(); // Collection of sets for the exercise

    public string Note { get; set; } = string.Empty;
}
