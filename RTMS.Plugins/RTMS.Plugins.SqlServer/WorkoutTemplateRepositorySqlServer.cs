using Dapper;
using RTMS.CoreBusiness.WorkoutTemplate;
using RTMS.UseCases.PluginInterfaces;
using System.Data;

namespace RTMS.Plugins.SqlServer;

public class WorkoutTemplateRepositorySqlServer : IWorkoutTemplateRepository
{
    private readonly SqlConnectionFactory _connectionFactory;

    public WorkoutTemplateRepositorySqlServer(SqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<List<WorkoutTemplate>> GetWorkoutTemplatesByUserIdAsync(Guid userId)
    {
        using var connection = _connectionFactory.CreateConnection();
        string query = "SELECT * FROM WorkoutTemplates WHERE OwnerId = @UserId";
        var workoutTemplates = await connection.QueryAsync<WorkoutTemplate>(query, new { UserId = userId });

        // Optionally, load related entities like Exercises and Sets here
        foreach (var template in workoutTemplates)
        {
            template.Exercises = await GetExercisesByTemplateIdAsync(template.Id, connection);
        }

        return workoutTemplates.ToList();
    }

    public async Task<WorkoutTemplate> GetWorkoutTemplateByIdAsync(int id)
    {
        using var connection = _connectionFactory.CreateConnection();
        string query = "SELECT * FROM WorkoutTemplates WHERE Id = @Id";
        var workoutTemplate = await connection.QueryFirstOrDefaultAsync<WorkoutTemplate>(query, new { Id = id });

        if (workoutTemplate != null)
        {
            workoutTemplate.Exercises = await GetExercisesByTemplateIdAsync(id, connection);
        }

        return workoutTemplate;
    }

    public async Task AddWorkoutTemplateAsync(WorkoutTemplate workoutTemplate)
    {
        using var connection = _connectionFactory.CreateConnection();

        // Insert WorkoutTemplate and retrieve the generated Id
        string query = @"INSERT INTO WorkoutTemplates (UserId, Name) 
                     VALUES (@UserId, @Name);
                     SELECT CAST(SCOPE_IDENTITY() as int);";

        workoutTemplate.Id = await connection.ExecuteScalarAsync<int>(query, workoutTemplate);

        // Insert related Exercises and Sets
        if (workoutTemplate.Exercises != null)
        {
            foreach (var exercise in workoutTemplate.Exercises)
            {
                exercise.WorkoutTemplateId = workoutTemplate.Id;
                await AddExerciseAsync(exercise, connection);
            }
        }
    }

    public async Task UpdateWorkoutTemplateAsync(WorkoutTemplate workoutTemplate)
    {
        using var connection = _connectionFactory.CreateConnection();
        string query = "UPDATE WorkoutTemplates SET Name = @Name WHERE Id = @Id";
        await connection.ExecuteAsync(query, workoutTemplate);

        // Update related Exercises and Sets
        foreach (var exercise in workoutTemplate.Exercises)
        {
            await UpdateExerciseAsync(exercise, connection);
        }
    }

    public async Task DeleteWorkoutTemplateAsync(int id)
    {
        using var connection = _connectionFactory.CreateConnection();

        // Delete related Exercises and Sets first
        await DeleteExercisesByTemplateIdAsync(id, connection);

        string query = "DELETE FROM WorkoutTemplates WHERE Id = @Id";
        await connection.ExecuteAsync(query, new { Id = id });
    }

    // Private methods to manage related entities
    private async Task<List<ExerciseTemplate>> GetExercisesByTemplateIdAsync(int workoutTemplateId, IDbConnection connection)
    {
        string query = "SELECT * FROM ExerciseTemplates WHERE WorkoutTemplateId = @WorkoutTemplateId";
        var exercises = await connection.QueryAsync<ExerciseTemplate>(query, new { WorkoutTemplateId = workoutTemplateId });

        foreach (var exercise in exercises)
        {
            exercise.Sets = await GetExerciseSetsByExerciseIdAsync(exercise.Id, connection);
        }

        return exercises.ToList();
    }

    private async Task<List<ExerciseSetTemplate>> GetExerciseSetsByExerciseIdAsync(int exerciseId, IDbConnection connection)
    {
        string query = "SELECT * FROM ExerciseSetTemplates WHERE ExerciseTemplateId = @ExerciseId";
        return (await connection.QueryAsync<ExerciseSetTemplate>(query, new { ExerciseId = exerciseId })).ToList();
    }

    private async Task AddExerciseAsync(ExerciseTemplate exercise, IDbConnection connection)
    {
        // Insert Exercise and retrieve the generated Id
        string query = @"INSERT INTO Exercises (WorkoutTemplateId, [Order], Name, RestTimerValue, RestTimerUnit, Note) 
                         VALUES (@WorkoutTemplateId, @Order, @Name, @RestTimerValue, @RestTimerUnit, @Note);
                         SELECT CAST(SCOPE_IDENTITY() as int);";

        exercise.Id = await connection.ExecuteScalarAsync<int>(query, exercise);

        // Insert related Sets
        if (exercise.Sets != null)
        {
            foreach (var set in exercise.Sets)
            {
                set.ExerciseTemplateId = exercise.Id;
                await AddExerciseSetAsync(set, connection);
            }
        }
    }

    private async Task AddExerciseSetAsync(ExerciseSetTemplate set, IDbConnection connection)
    {
        string query = @"INSERT INTO ExerciseSets (ExerciseTemplateId, Reps, Weight) 
                         VALUES (@ExerciseTemplateId, @Reps, @Weight)";

        await connection.ExecuteAsync(query, set);
    }

    private async Task UpdateExerciseAsync(ExerciseTemplate exercise, IDbConnection connection)
    {
        string query = "UPDATE ExerciseTemplates SET Name = @Name, [Order] = @Order WHERE Id = @Id";
        await connection.ExecuteAsync(query, exercise);

        foreach (var set in exercise.Sets)
        {
            await UpdateExerciseSetAsync(set, connection);
        }
    }

    private async Task UpdateExerciseSetAsync(ExerciseSetTemplate set, IDbConnection connection)
    {
        string query = "UPDATE ExerciseSetTemplates SET Reps = @Reps, Weight = @Weight WHERE Id = @Id";
        await connection.ExecuteAsync(query, set);
    }

    private async Task DeleteExercisesByTemplateIdAsync(int workoutTemplateId, IDbConnection connection)
    {
        string query = "DELETE FROM ExerciseTemplates WHERE WorkoutTemplateId = @WorkoutTemplateId";
        await connection.ExecuteAsync(query, new { WorkoutTemplateId = workoutTemplateId });
    }
}
