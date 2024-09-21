using System.ComponentModel.DataAnnotations;

namespace RTMS.CoreBusiness;

public class WorkoutTemplate : BaseEntity
{
    [Required]
    public Guid UserId { get; set; }

    public User User { get; set; }

    [Required]
    public string Name { get; set; }

    public DateTime CreatedAt { get; set; }

    public ICollection<ExerciseTemplate> Exercises { get; set; } = new List<ExerciseTemplate>();

    public ICollection<ClientWorkoutTemplate> ClientWorkoutTemplates { get; set; } = new List<ClientWorkoutTemplate>();

    public bool IsTrainerCreated { get; set; }
}