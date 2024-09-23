using Microsoft.EntityFrameworkCore;
using Moq;
using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.Workouts;
using RTMS.UseCases.Workouts.Interfaces;

namespace RTMS.Tests.UseCases.WorkoutUseCases;

public class AddWorkoutUseCaseTest
{
    private readonly Mock<IWorkoutHistoryRepository> _mockRepository;
    private readonly IAddWorkoutUseCase _useCase;

    public AddWorkoutUseCaseTest()
    {
        _mockRepository = new Mock<IWorkoutHistoryRepository>();
        _useCase = new AddWorkoutUseCase(_mockRepository.Object);
    }

    private Workout CreateSampleWorkout() => new()
    {
        UserId = Guid.NewGuid(),
        Name = "Upper Body Workout",
        StartTime = DateTime.UtcNow,
        IsCompleted = false,
        Exercises =
        [
            new()
            {
                Name = "Bench Press",
                RestTimerValue = 2,
                RestTimerUnit = "minutes",
                Note = "Focus on form and controlled descent",
                Sets =
                [
                    new() { Reps = 8, Weight = 135 },
                    new() { Reps = 8, Weight = 145 },
                    new() { Reps = 6, Weight = 155 }
                ]
            },
        ]
    };

    [Fact]
    public async Task ExecuteAsync_WithValidWorkout_ShouldAddToRepository()
    {
        // Arrange
        var workout = CreateSampleWorkout();

        // Act
        await _useCase.ExecuteAsync(workout);

        // Assert
        _mockRepository.Verify(r => r.AddWorkoutAsync(It.Is<Workout>(w =>
            w.Name == workout.Name &&
            w.UserId == workout.UserId &&
            w.StartTime == workout.StartTime &&
            w.IsCompleted == workout.IsCompleted &&
            w.Exercises.Count == workout.Exercises.Count &&
            w.Exercises.All(e => workout.Exercises.Any(te => te.Name == e.Name &&
                te.RestTimerValue == e.RestTimerValue &&
                te.RestTimerUnit == e.RestTimerUnit &&
                te.Note == e.Note &&
                te.Sets.Count == e.Sets.Count &&
                te.Sets.All(s => e.Sets.Any(ts => ts.Reps == s.Reps && ts.Weight == s.Weight))
            ))
        )), Times.Once);
    }

    [Fact]
    public async Task ExecuteAsync_WithNullWorkout_ShouldThrowArgumentNullException()
    {
        // Arrange
        Workout nullWorkout = null;

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _useCase.ExecuteAsync(nullWorkout));
        Assert.Equal("workout", exception.ParamName);
    }

    [Fact]
    public async Task ExecuteAsync_WhenDbUpdateExceptionThrown_ShouldHandleGracefully()
    {
        // Arrange
        var workout = CreateSampleWorkout();
        _mockRepository.Setup(r => r.AddWorkoutAsync(It.IsAny<Workout>()))
                       .ThrowsAsync(new DbUpdateException());

        // Act & Assert
        var exception = await Assert.ThrowsAsync<DbUpdateException>(() => _useCase.ExecuteAsync(workout));
        Assert.Contains("An error occurred while adding the workout", exception.Message);
    }
}
