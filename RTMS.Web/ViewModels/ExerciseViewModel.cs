namespace RTMS.Web.ViewModels;

public class ExerciseViewModel
{
    public int Id { get; set; }

    public int WorkoutId { get; set; } // Link to the Workout
    public int ExerciseTemplateId { get; set; }  // Foreign key to ExerciseTemplate
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

    public List<ExerciseSetViewModel>? Sets { get; set; } = new();

    public string Note { get; set; } = string.Empty;

    public bool IsRestTimerOpen { get; set; } = false;

    public bool IsNotePopOverOpen { get; set; } = false;

}
