using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Newtonsoft.Json;
using RTMS.Web.Dtos;
using System.Text;

namespace RTMS.Web.Services;

public class Auth0UserService(ManagementApiClient managementClient, HttpClient httpClient, string auth0Domain, string clientId)
{
    public async Task<IList<Auth0UserDto>> GetUsersAsync(string roleFilter = null)
    {
        var users = new List<Auth0UserDto>();
        try
        {
            var auth0Users = await managementClient.Users.GetAllAsync(new GetUsersRequest());
            foreach (var user in auth0Users)
            {
                try
                {
                    var roles = await managementClient.Users.GetRolesAsync(user.UserId);
                    var userRoles = roles.Select(r => r.Name).ToList();
                    // Apply role filter if provided
                    if (roleFilter == null || userRoles.Contains(roleFilter))
                    {
                        users.Add(new Auth0UserDto
                        {
                            UserId = user.UserId,
                            FullName = user.FullName,
                            Email = user.Email,
                            Roles = userRoles
                        });
                    }
                }
                catch (Exception ex)
                {
                    // Handle the case where roles could not be fetched for a specific user
                    Console.Error.WriteLine($"Failed to get roles for user {user.UserId}: {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            // Handle general errors
            Console.Error.WriteLine($"Failed to fetch users: {ex.Message}");
        }

        return users;
    }

    public async Task<IList<Role>> GetAllRolesAsync()
    {
        return await managementClient.Roles.GetAllAsync(new GetRolesRequest());
    }

    public async Task UpdateUserRoleAsync(string userId, string roleId)
    {
        var currentRoles = await managementClient.Users.GetRolesAsync(userId);
        var currentRoleIds = currentRoles.Select(r => r.Id).ToArray();

        if (currentRoleIds.Any())
        {
            await managementClient.Users.RemoveRolesAsync(userId, new AssignRolesRequest { Roles = currentRoleIds });
        }

        await managementClient.Users.AssignRolesAsync(userId, new AssignRolesRequest { Roles = [roleId] });
    }

    public async Task<Auth0UserDto> GetUserByIdAsync(string userId)
    {
        var user = await managementClient.Users.GetAsync(userId);
        var roles = await managementClient.Users.GetRolesAsync(userId);
        return new Auth0UserDto
        {
            UserId = user.UserId,
            FullName = user.FullName,
            Email = user.Email,
            Roles = roles.Select(r => r.Name).ToList(),
            SelectedRoleId = roles.FirstOrDefault()?.Id
        };
    }

    public async Task DeleteUserAsync(string userId)
    {
        await managementClient.Users.DeleteAsync(userId);
    }

    public async Task CreateUserAndSendResetEmailAsync(string email, string roleId)
    {
        // Create the user
        var user = new UserCreateRequest
        {
            Email = email,
            Password = GenerateRandomPassword(),
            Connection = "Username-Password-Authentication",
            EmailVerified = false,
            VerifyEmail = false
        };

        var createdUser = await managementClient.Users.CreateAsync(user);

        // Assign a role to the user
        if (!string.IsNullOrEmpty(roleId))
        {
            await managementClient.Users.AssignRolesAsync(createdUser.UserId, new AssignRolesRequest
            {
                Roles = [roleId]
            });
        }

        // Send password reset email
        await SendPasswordResetEmailAsync(email, "Username-Password-Authentication");
    }

    private async Task SendPasswordResetEmailAsync(string email, string connection)
    {
        var requestUri = $"https://{auth0Domain}/dbconnections/change_password";

        var requestBody = new
        {
            client_id = clientId,
            email = email,
            connection = connection,
        };

        var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(requestUri, content);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Password reset email sent successfully.");
        }
        else
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            Console.Error.WriteLine($"Failed to send password reset email: {errorContent}");
        }
    }

    private string GenerateRandomPassword(int length = 12)
    {
        const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";
        var random = new Random();
        return new string(Enumerable.Repeat(validChars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
