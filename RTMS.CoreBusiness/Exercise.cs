using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RTMS.CoreBusiness;
public class Exercise : BaseEntity
{
    [Required]
    public string Name { get; set; }

    [ForeignKey("WorkoutId")]
    public int WorkoutId { get; set; }

    public Workout Workout { get; set; }

    [ForeignKey("ExerciseTemplateId")]
    public int? ExerciseTemplateId { get; set; }

    public ExerciseTemplate ExerciseTemplate { get; set; }

    public int RestTimerValue { get; set; } = 0;

    public string RestTimerUnit { get; set; } = "minutes";

    public int RestTimerSecondsBetweenSets
    {
        get
        {
            return RestTimerUnit switch
            {
                "minutes" => RestTimerValue * 60,
                "seconds" => RestTimerValue,
                _ => 0,
            };
        }
    }

    public double TotalExerciseVolume => GetTotalExerciseVolume();

    public double GetTotalExerciseVolume()
    {
        double totalVolume = 0;

        foreach (var set in Sets)
        {
            totalVolume += set.Reps * set.Weight;
        }

        return totalVolume;
    }

    public ICollection<ExerciseSet> Sets { get; set; } = new List<ExerciseSet>();

    public string? Note { get; set; }
}