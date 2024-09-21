using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RTMS.CoreBusiness;
public class ExerciseSet
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("ExerciseId")]
    public int ExerciseId { get; set; }
    public virtual Exercise Exercise { get; set; }
    [ForeignKey("SetTemplateId")]
    public int? SetTemplateId { get; set; }

    public virtual ExerciseSetTemplate ExerciseSetTemplate { get; set; }
    [Required]
    public int Reps { get; set; }

    [Required]
    public double Weight { get; set; }
}