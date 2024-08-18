using RTMS.CoreBusiness.Active;

namespace RTMS.Web.ViewModels;

public class ExerciseViewModel
{
    public Exercise Exercise { get; set; }
    public List<ExerciseSetViewModel> Sets { get; set; } = new();

    public ExerciseViewModel(Exercise exercise)
    {
        Exercise = exercise;
        Sets = exercise.Sets.Select(s => new ExerciseSetViewModel(s)).ToList();
    }
}
