using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace RTMS.Web.Services
{
    public class UserContextService(AuthenticationStateProvider authenticationStateProvider)
    {
        public async Task<string?> GetUserIdAsync()
        {
            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            return user.Identity?.IsAuthenticated == true
                ? user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value
                : null;
        }

        public async Task<string?> GetUserEmailAsync()
        {
            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            return user.Identity?.IsAuthenticated == true
                ? user.FindFirst(c => c.Type == ClaimTypes.Email)?.Value
                : null;
        }
    }
}
