using System.ComponentModel.DataAnnotations;

namespace RTMS.CoreBusiness.Active;
public class ExerciseSet
{
    public int Id { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Reps must be at least 1.")]
    public int Reps { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Weight must be non-negative.")]
    public double Weight { get; set; }

    public bool IsCompleted { get; set; }  // Flag to indicate if the set is completed

    public int RemainingRestTime { get; set; } // Tracks remaining rest time for the set
}
