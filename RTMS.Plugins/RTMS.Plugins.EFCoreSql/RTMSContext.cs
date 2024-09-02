using Microsoft.EntityFrameworkCore;
using RTMS.CoreBusiness.Active;
using RTMS.CoreBusiness.Template;

namespace RTMS.Plugins.EFCoreSql;

public class RTMSContext : DbContext
{
    public RTMSContext(DbContextOptions<RTMSContext> options) : base(options)
    {

    }

    public DbSet<WorkoutTemplate>? WorkoutTemplates { get; set; }
    public DbSet<ExerciseTemplate>? ExerciseTemplates { get; set; }
    public DbSet<ExerciseTemplateSet>? ExerciseTemplateSets { get; set; }

    public DbSet<Workout>? Workouts { get; set; }
    public DbSet<Exercise>? Exercises { get; set; }
    public DbSet<ExerciseSet>? ExerciseSets { get; set; }
}