using RTMS.CoreBusiness.Active;

namespace RTMS.Web.ViewModels;

public class ExerciseSetViewModel
{
    public ExerciseSet ExerciseSet { get; set; }
    public bool IsCompleted { get; set; }
    public int InitialRestTime { get; set; }
    public int RemainingRestTime { get; set; }

    public ExerciseSetViewModel(ExerciseSet exerciseSet)
    {
        ExerciseSet = exerciseSet;
        InitialRestTime = exerciseSet.InitialRestTime;
        RemainingRestTime = exerciseSet.InitialRestTime;
    }

    // Mark the set as completed
    public void MarkAsCompleted()
    {
        IsCompleted = true;
        RemainingRestTime = InitialRestTime;
    }

    // Reset the set to incomplete status
    public void ResetSet()
    {
        IsCompleted = false;
        RemainingRestTime = InitialRestTime;
    }

    // Decrease the remaining rest time by one second
    public void DecrementRestTime()
    {
        if (RemainingRestTime > 0)
        {
            RemainingRestTime--;
        }
        else
        {
            RemainingRestTime = -1; // Set to -1 to indicate the timer is hidden
        }
    }

    // Check if the rest time is still active
    public bool IsRestTimeActive()
    {
        return RemainingRestTime > 0;
    }
}