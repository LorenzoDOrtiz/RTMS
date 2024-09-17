namespace RTMS.CoreBusiness;

public class TrainerClient
{
    public Guid? TrainerId { get; set; }
    public User? Trainer { get; set; }

    public Guid? ClientId { get; set; }
    public User? Client { get; set; }
}
