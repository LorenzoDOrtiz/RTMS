using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RTMS.CoreBusiness;
public class ExerciseSet : BaseEntity
{
    [ForeignKey("ExerciseId")]
    public int ExerciseId { get; set; }

    public Exercise Exercise { get; set; }

    [ForeignKey("SetTemplateId")]
    public int? SetTemplateId { get; set; }

    public ExerciseSetTemplate ExerciseSetTemplate { get; set; }

    [Required]
    public int Reps { get; set; }

    [Required]
    public double Weight { get; set; }
}