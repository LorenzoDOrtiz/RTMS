namespace RTMS.CoreBusiness.Active;
public class Exercise
{
    public int Id { get; set; }

    public int WorkoutId { get; set; } // Link to the Workout

    public string Name { get; set; }

    public int RestTimerValue { get; set; } = 0;

    public string RestTimerUnit { get; set; } = "minutes";

    public int RestTimerSecondsBetweenSets
    {
        get
        {
            return RestTimerUnit switch
            {
                "minutes" => RestTimerValue * 60,
                "seconds" => RestTimerValue,
                _ => 0, // Default or handle other units if necessary
            };
        }
    }

    public List<ExerciseSet> Sets { get; set; } = new(); // Collection of sets for the exercise

    public string Note { get; set; } = string.Empty;
}