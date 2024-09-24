using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Newtonsoft.Json;
using RTMS.UseCases.Users.Interfaces;
using RTMS.Web.Dtos;
using System.Text;

namespace RTMS.Web.Services;

public class Auth0UserService(ManagementApiClient managementClient, HttpClient httpClient, IGetOrCreateUserUseCase getOrCreateUserUseCase,
string auth0Domain, string clientId)
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
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            FullName = user.FullName,
                            PhoneNumber = user.PhoneNumber,
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


    public async Task<IList<Auth0UserDto>> GetUsersByRole(string roleId)
    {
        var users = new List<Auth0UserDto>();  // Corrected from AssignedUser
        try
        {
            // Fetch all users for the given role
            var auth0Users = await managementClient.Roles.GetUsersAsync(roleId);

            foreach (var user in auth0Users)
            {
                users.Add(new Auth0UserDto
                {
                    UserId = user.UserId,
                    FullName = user.FullName
                });
            }
        }
        catch (Exception ex)
        {
            // Log general error during fetching users
            Console.Error.WriteLine($"Failed to fetch users for role {roleId}: {ex.Message}");
        }

        return users;
    }

    public async Task<IList<Role>> GetAllRolesAsync(string roleFilter = null)
    {
        var roles = new List<Role>();

        var allRoles = await managementClient.Roles.GetAllAsync(new GetRolesRequest());

        // Apply role filter if provided
        if (roleFilter == null)
        {
            roles = allRoles.ToList();
        }
        else
        {
            roles = allRoles.Where(role => role.Name == roleFilter).ToList();
        }


        return roles;
    }

    public async Task UpdateUserRoleAsync(string userId, IEnumerable<string> roleIds)
    {
        var currentRoles = await managementClient.Users.GetRolesAsync(userId);
        var currentRoleIds = currentRoles.Select(r => r.Id).ToArray();

        if (currentRoleIds.Any())
        {
            await managementClient.Users.RemoveRolesAsync(userId, new AssignRolesRequest { Roles = currentRoleIds });
        }

        if (roleIds.Any())
        {
            await managementClient.Users.AssignRolesAsync(userId, new AssignRolesRequest { Roles = roleIds.ToArray() });

        }
    }

    public async Task<Auth0UserDto> GetUserByIdAsync(string userId)
    {
        var user = await managementClient.Users.GetAsync(userId);
        var roles = await managementClient.Users.GetRolesAsync(userId);
        return new Auth0UserDto
        {
            UserId = user.UserId,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            Email = user.Email,
            Roles = roles.Select(r => r.Name).ToList(),
            SelectedRoleIds = roles.Select(r => r.Id).ToList()
        };
    }

    public async Task DeleteUserAsync(string userId)
    {
        await managementClient.Users.DeleteAsync(userId);
    }

    public async Task<string> CreateUserAndSendResetEmailAsync(string firstName, string lastName, string fullName, string phoneNumber, string email, string roleId)
    {
        // Create the user
        var user = new UserCreateRequest
        {
            FirstName = firstName,
            LastName = lastName,
            FullName = fullName,
            PhoneNumber = phoneNumber,
            Email = email,
            Password = GenerateRandomPassword(),
            Connection = "Username-Password-Authentication",
            EmailVerified = false,
            VerifyEmail = false
        };

        try
        {
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

            // Manually add the user to the database
            await getOrCreateUserUseCase.ExecuteAsync(createdUser.UserId, createdUser.FirstName, createdUser.LastName, createdUser.Email);

            return createdUser.UserId;

        }
        catch (Auth0.Core.Exceptions.ErrorApiException e)
        {
            if (e.ApiError != null && e.ApiError.Message.Contains("phone_number"))
            {
                // Handle specific invalid phone number case
                throw new Exception("Invalid phone number. Please check the number and try again.");
            }
            else
            {
                // Handle other Auth0 errors (could be email, user creation, etc.)
                throw new Exception($"An error occurred: {e.ApiError?.Message}");
            }
        }
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

            Console.Error.WriteLine($"Failed to send password reset email:0. {errorContent}");
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
