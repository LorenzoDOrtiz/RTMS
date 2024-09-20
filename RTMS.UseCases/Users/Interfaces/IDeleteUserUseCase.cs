namespace RTMS.UseCases.Users.Interfaces;

public interface IDeleteUserUseCase
{
    Task ExecuteAsync(Guid userId);
}