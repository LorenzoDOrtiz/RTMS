namespace RTMS.Web.ViewModels
{
    public class ExerciseTemplateViewModel
    {
        public int WorkoutTemplateId { get; set; }

        public int Order { get; set; }

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int RestTimerValue { get; set; } = 0;

        public string RestTimerUnit { get; set; } = "minutes";

        public List<ExerciseSetTemplateViewModel>? Sets { get; set; }

        public string Note { get; set; } = string.Empty;

        public bool IsRestTimerOpen { get; set; } = false;

        public bool IsNotePopOverOpen { get; set; } = false;
    }
}
