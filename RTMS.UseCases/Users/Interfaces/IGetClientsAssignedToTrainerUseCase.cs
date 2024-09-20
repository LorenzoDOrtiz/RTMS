using RTMS.CoreBusiness;

namespace RTMS.UseCases.Users.Interfaces;

public interface IGetClientsAssignedToTrainerUseCase
{
    Task<IEnumerable<User>> ExecuteAsync(Guid trainerUserId);
}