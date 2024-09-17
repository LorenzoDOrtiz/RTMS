namespace RTMS.UseCases.Users.Interfaces;

public interface IAddTrainerClientRelationshipUseCase
{
    Task ExecuteAsync(Guid clientUserId, Guid trainerUserId);
}