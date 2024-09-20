using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Users.Interfaces;

namespace RTMS.UseCases.Users;
public class DeleteUserUseCase(IUserRepositoryPostgreEFCore userRepositoryPostgreEFCore) : IDeleteUserUseCase
{
    public async Task ExecuteAsync(Guid userId)
    {
        await userRepositoryPostgreEFCore.DeleteUserAsync(userId);
    }
}
