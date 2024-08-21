using RTMS.CoreBusiness.Active;

namespace RTMS.Web.ViewModels;

public class ExerciseSetViewModel
{
    public ExerciseSet ExerciseSet { get; set; }
    public bool IsCompleted { get; set; }

    public ExerciseSetViewModel(ExerciseSet exerciseSet)
    {
        ExerciseSet = exerciseSet;
    }

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