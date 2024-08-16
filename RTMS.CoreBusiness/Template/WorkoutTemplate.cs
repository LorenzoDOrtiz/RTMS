using System.ComponentModel.DataAnnotations;

namespace RTMS.CoreBusiness.Template;

public class WorkoutTemplate
{
    public int Id { get; set; }
    public int UserId { get; set; } // Link to ASP.NET Core Identity User

    [Required]
    public string Name { get; set; }

    [Required]
    public List<ExerciseTemplate> Exercises { get; set; } = new();
}