using Microsoft.EntityFrameworkCore;
using Moq;
using RTMS.CoreBusiness;
using RTMS.UseCases.PluginInterfaces;
using RTMS.UseCases.WorkoutTemplates;
using RTMS.UseCases.WorkoutTemplates.Interfaces;

namespace RTMS.Tests.UseCases.WorkoutTemplateUseCases;

public class AddWorkoutTemplateUseCaseTest
{
    private readonly Mock<IWorkoutTemplateRepository> _mockRepository;
    private readonly IAddWorkoutTemplateUseCase _useCase;

    public AddWorkoutTemplateUseCaseTest()
    {
        _mockRepository = new Mock<IWorkoutTemplateRepository>();
        _useCase = new AddWorkoutTemplateUseCase(_mockRepository.Object);
    }

    private WorkoutTemplate CreateSampleWorkoutTemplate() => new()
    {
        UserId = Guid.NewGuid(),
        Name = "Upper Body Strength",
        CreatedAt = DateTime.UtcNow,
        IsTrainerCreated = true,
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
    public async Task ExecuteAsync_WithValidWorkoutTemplate_ShouldAddToRepository()
    {
        // Arrange
        var workoutTemplate = CreateSampleWorkoutTemplate();

        // Act
        await _useCase.ExecuteAsync(workoutTemplate);

        // Assert
        _mockRepository.Verify(r => r.AddWorkoutTemplateAsync(It.Is<WorkoutTemplate>(wt =>
            wt.Name == workoutTemplate.Name &&
            wt.UserId == workoutTemplate.UserId &&
            wt.CreatedAt == workoutTemplate.CreatedAt &&
            wt.IsTrainerCreated == workoutTemplate.IsTrainerCreated &&
            wt.Exercises.Count == workoutTemplate.Exercises.Count &&
            wt.Exercises.All(e => workoutTemplate.Exercises.Any(te => te.Name == e.Name &&
                te.RestTimerValue == e.RestTimerValue &&
                te.RestTimerUnit == e.RestTimerUnit &&
                te.Note == e.Note &&
                te.Sets.Count == e.Sets.Count &&
                te.Sets.All(s => e.Sets.Any(ts => ts.Reps == s.Reps && ts.Weight == s.Weight))
            ))
        )), Times.Once);
    }

    [Fact]
    public async Task ExecuteAsync_WithNullWorkoutTemplate_ShouldThrowArgumentNullException()
    {
        // Arrange
        WorkoutTemplate nullTemplate = null;

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _useCase.ExecuteAsync(nullTemplate));
        Assert.Equal("workoutTemplate", exception.ParamName);
    }

    [Fact]
    public async Task ExecuteAsync_WhenDbUpdateExceptionThrown_ShouldHandleGracefully()
    {
        // Arrange
        var workoutTemplate = CreateSampleWorkoutTemplate();
        _mockRepository.Setup(r => r.AddWorkoutTemplateAsync(It.IsAny<WorkoutTemplate>()))
                       .ThrowsAsync(new DbUpdateException());

        // Act & Assert
        var exception = await Assert.ThrowsAsync<DbUpdateException>(() => _useCase.ExecuteAsync(workoutTemplate));
        Assert.Contains("An error occurred while adding the workout template", exception.Message);
    }
}