namespace RTMS.Web.ViewModels
{
    public class WorkoutTemplateViewModel
    {
        public Guid UserId { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<ExerciseTemplateViewModel>? Exercises { get; set; } = new List<ExerciseTemplateViewModel>();
    }
}
