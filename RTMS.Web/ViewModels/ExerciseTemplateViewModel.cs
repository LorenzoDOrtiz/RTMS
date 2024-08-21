using RTMS.CoreBusiness.Template;

namespace RTMS.Web.ViewModels;

public class ExerciseTemplateViewModel
{
    public int Id { get; set; }

    public int WorkoutTemplateId { get; set; }

    public string Name { get; set; }

    public bool IsRestTimerOpen { get; set; } = false;

    public int RestTimerValue { get; set; } = 0;

    public string RestTimerUnit { get; set; } = "minutes";

    public List<ExerciseTemplateSet> Sets { get; set; }

    public string Note { get; set; } = string.Empty;
}
