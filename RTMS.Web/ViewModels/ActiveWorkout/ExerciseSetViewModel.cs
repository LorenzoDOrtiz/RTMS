namespace RTMS.Web.ViewModels.ActiveWorkout;

public class ExerciseSetViewModel
{
    public int Id { get; set; }

    public int Reps { get; set; }

    public double Weight { get; set; }

    // UI-specific property to track whether the set is completed
    public bool IsCompleted { get; set; }

    // Mark the set as completed
    public void MarkAsCompleted()
    {
        IsCompleted = true;
    }

    // Reset the set to incomplete status
    public void ResetSet()
    {
        IsCompleted = false;
    }
}