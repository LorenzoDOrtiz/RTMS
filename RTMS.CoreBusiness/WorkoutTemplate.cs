using System.ComponentModel.DataAnnotations;

namespace RTMS.CoreBusiness;

public class WorkoutTemplate
{
    [Key]
    public int Id { get; set; }

    [Required]
    public Guid UserId { get; set; }

    public User User { get; set; }

    [Required]
    public string Name { get; set; }

    public virtual ICollection<ExerciseTemplate> Exercises { get; set; } = new List<ExerciseTemplate>();
}