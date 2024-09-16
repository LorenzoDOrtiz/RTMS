using Microsoft.AspNetCore.Components.Authorization;
using RTMS.UseCases.Users.Interfaces;
using System.Security.Claims;

namespace RTMS.Web.Services;

public class UserService(AuthenticationStateProvider authenticationStateProvider, IGetOrCreateUserUseCase getOrCreateUserUseCase)
{

    // Cache user details after loading
    public Guid UserId { get; private set; }
    public string UserName { get; private set; }
    public string UserEmail { get; private set; }
    public bool IsUserAuthenticated { get; private set; }
    public bool IsAdmin { get; private set; }

    public async Task LoadUserAsync()
    {
        var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity?.IsAuthenticated == true)
        {
            var auth0UserId = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value
                              ?? throw new Exception("Auth0 user ID not found.");

            var userEmail = user.FindFirst(c => c.Type == ClaimTypes.Email)?.Value ?? string.Empty;
            var userName = user.Identity.Name ?? string.Empty;

            var internalUser = await getOrCreateUserUseCase.ExecuteAsync(auth0UserId, userEmail, userName);
            UserId = internalUser.Id;
            UserName = internalUser.Name;
            UserEmail = internalUser.Email;
            IsUserAuthenticated = user.Identity.IsAuthenticated;
            IsAdmin = user.IsInRole("Admin");
        }
        else
        {
            throw new UnauthorizedAccessException();
        }
    }
}
