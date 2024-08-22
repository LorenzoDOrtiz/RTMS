using RTMS.Web.ViewModels.Active;

namespace RTMS.Web.ViewModels.WorkoutTemplate;

public class ExerciseTemplateViewModel
{
    public int Id { get; set; }

    public int WorkoutTemplateId { get; set; }

    public string Name { get; set; }

    public bool IsRestTimerOpen { get; set; } = false;

    public int RestTimerValue { get; set; } = 0;

    public string RestTimerUnit { get; set; } = "minutes";

    public List<ExerciseTemplateSetViewModel> Sets { get; set; }

    public string Note { get; set; } = string.Empty;
}