using Microsoft.EntityFrameworkCore;
using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;

namespace RTMS.Plugins.PostgreEFCore;

public class UserRepositoryPostgreEFCore(IDbContextFactory<RTMSDBContext> contextFactory) : IUserRepositoryPostgreEFCore
{

    // Get a user by Auth0 ID (or any other identifier like email)
    public async Task<User?> GetUserByAuth0IdAsync(string auth0Id)
    {
        using var context = contextFactory.CreateDbContext();
        return await context.Users
            .AsNoTracking() // Use AsNoTracking to improve performance if the entity isn't being updated
            .FirstOrDefaultAsync(u => u.Auth0Id == auth0Id);
    }

    // Create a new user
    public async Task<User> CreateUserAsync(User user)
    {
        using var context = contextFactory.CreateDbContext();
        context.Users.Add(user);
        await context.SaveChangesAsync();
        return user;
    }

    // Update an existing user
    public async Task<User> UpdateUserAsync(User user)
    {
        using var context = contextFactory.CreateDbContext();
        context.Users.Update(user);
        await context.SaveChangesAsync();
        return user;
    }

    // Check if a user exists by their Auth0 ID
    public async Task<bool> UserExistsAsync(string auth0Id)
    {
        using var context = contextFactory.CreateDbContext();
        return await context.Users
            .AnyAsync(u => u.Auth0Id == auth0Id);
    }

    public async Task<IEnumerable<Guid>?> GetTrainerIdsByUserIdAsync(Guid userId)
    {
        using var context = contextFactory.CreateDbContext();

        var trainerIds = await context.TrainerClients
            .AsNoTracking()
            .Where(tc => tc.ClientId == userId)
            .Select(tc => tc.TrainerId)
            .ToListAsync();

        return trainerIds.Count != 0 ? trainerIds : null;
    }

    public async Task<Guid> GetUserIdByAuth0IdAsync(string Auth0Id)
    {
        using var context = contextFactory.CreateDbContext();
        var user = await context.Users
            .AsNoTracking()
            .Where(u => u.Auth0Id == Auth0Id)
            .FirstOrDefaultAsync();

        return user.Id;
    }

    public async Task<IEnumerable<Guid>?> GetUserIdsByAuth0IdsAsync(IEnumerable<string> auth0Ids)
    {
        using var context = contextFactory.CreateDbContext();

        var userIds = await context.Users
            .AsNoTracking()
            .Where(u => auth0Ids.Contains(u.Auth0Id)) // Filter users by matching Auth0Id values
            .Select(u => u.Id) // Select the UserId (Guid)
            .ToListAsync();

        return userIds.Any() ? userIds : null; // Return the list or null if no results
    }

    public async Task AddTrainerClientRelationshipAsync(Guid clientUserId, IEnumerable<Guid> trainerUserIds)
    {
        using var context = contextFactory.CreateDbContext();

        foreach (var trainerUserId in trainerUserIds)
        {
            context.TrainerClients.Add(new TrainerClient
            {
                ClientId = clientUserId,
                TrainerId = trainerUserId
            });
        }

        // Save changes asynchronously
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<string>?> GetAuth0UserIdsByUserIds(IEnumerable<Guid> userIds)
    {
        using var context = contextFactory.CreateDbContext();

        var users = await context.Users
            .AsNoTracking()
            .Where(u => userIds.Contains(u.Id))
            .Select(u => u.Auth0Id)
            .ToListAsync();

        return users.Any() ? users : null;
    }

    public Task<IEnumerable<Guid>?> GetUserIdByAuth0IdAsync(IEnumerable<string> Auth0Id)
    {
        throw new NotImplementedException();
    }

    public void UpdateClientTrainers(Guid userId, IEnumerable<Guid> trainerIds)
    {
        using var context = contextFactory.CreateDbContext();

        var existingClientTrainers = context.TrainerClients
            .Where(ct => ct.ClientId == userId);

        if (existingClientTrainers.Any())
        {
            context.TrainerClients.RemoveRange(existingClientTrainers);

        }

        if (trainerIds.Any())
        {
            foreach (var trainerId in trainerIds)
            {
                var newClientTrainer = new TrainerClient
                {
                    ClientId = userId,
                    TrainerId = trainerId
                };

                context.TrainerClients.Add(newClientTrainer);
            }
        }

        context.SaveChanges();
    }

    public async Task<IEnumerable<User>> GetClientsAssignedToTrainerUseCase(Guid trainerUserId)
    {
        using var context = contextFactory.CreateDbContext();

        var clientIds = await context.TrainerClients
            .Where(tc => tc.TrainerId == trainerUserId)
            .Select(tc => tc.ClientId)
            .ToListAsync();

        if (clientIds == null || !clientIds.Any())
        {
            return [];
        }

        // Use these ClientIds to fetch the corresponding user records
        var clients = await context.Users
            .Where(user => clientIds.Contains(user.Id))
            .ToListAsync();

        // Return the result as IEnumerable<User>
        return clients;
    }

    public async Task RemoveClientFromTrainerUseCase(Guid clientId, Guid trainerId)
    {
        using var context = contextFactory.CreateDbContext();

        // Find the record that matches both clientId and trainerId
        var trainerClient = await context.TrainerClients
            .SingleOrDefaultAsync(tc => tc.ClientId == clientId && tc.TrainerId == trainerId);

        // Check if the record was found
        if (trainerClient != null)
        {
            // Remove the record from the context
            context.TrainerClients.Remove(trainerClient);

            // Save changes to the database asynchronously
            await context.SaveChangesAsync();
        }
    }

    public async Task DeleteUserAsync(Guid userId)
    {
        using var context = contextFactory.CreateDbContext();
        var userToDelete = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (userToDelete != null)
        {
            context.Users.Remove(userToDelete);
            await context.SaveChangesAsync();
        }
    }
}