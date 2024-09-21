namespace RTMS.CoreBusiness;

public class ClientWorkoutTemplate
{
    public Guid ClientId { get; set; }
    public User Client { get; set; }

    public int WorkoutTemplateId { get; set; }
    public WorkoutTemplate WorkoutTemplate { get; set; }

    public DateTime AssignedDate { get; set; }

    public string AssignedBy { get; set; }
}
