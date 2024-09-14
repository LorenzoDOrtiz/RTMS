using Microsoft.AspNetCore.Components.Authorization;
using RTMS.UseCases.Users.Interfaces;
using System.Security.Claims;

namespace RTMS.Web.Services
{
    // work needds to be done here to make this more effecient
    public class UserContextService(AuthenticationStateProvider authenticationStateProvider, IGetOrCreateUserUseCase getOrCreateUserUseCase)
    {
        public async Task<Guid> GetUserIdAsync()
        {
            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;


            if (user.Identity?.IsAuthenticated == true)
            {
                // Get the provider
                var providerKey = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                var provider = providerKey != null && providerKey.StartsWith("google", StringComparison.OrdinalIgnoreCase)
                    ? "Google"
                    : "defaultProvider";

                // Get the email
                var email = user.FindFirst(c => c.Type == ClaimTypes.Email)?.Value ?? string.Empty;

                // Get the name
                var name = user.Identity.Name;

                // Execute the use case with retrieved data
                var internalUser = await getOrCreateUserUseCase.ExecuteAsync(provider, providerKey, email, name);
                return internalUser.Id;
            }

            // Handle case where user is not authenticated
            throw new UnauthorizedAccessException();
        }
    }
}
