using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RTMS.CoreBusiness;
public class Workout : BaseEntity
{
    [Required]
    public Guid UserId { get; set; }

    public User User { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    [ForeignKey("WorkoutTemplateId")]
    public int? WorkoutTemplateId { get; set; }

    public WorkoutTemplate WorkoutTemplate { get; set; }

    public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();

    public double TotalWorkoutVolume => GetTotalWorkoutVolume();

    public bool IsCompleted { get; set; }

    public double GetTotalWorkoutVolume()
    {
        double totalVolume = 0;

        foreach (var exercise in Exercises)
        {
            foreach (var set in exercise.Sets)
            {
                totalVolume += set.Reps * set.Weight;
            }
        }

        return totalVolume;
    }

    public TimeSpan? Duration
    {
        get
        {
            if (EndTime.HasValue)
            {
                return EndTime.Value - StartTime;
            }
            return null;
        }
    }
}