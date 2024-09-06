using Microsoft.EntityFrameworkCore;
using RTMS.CoreBusiness;

namespace RTMS.Plugins.PostgreEFCore;
public class RTMSDBContext : DbContext
{
    public RTMSDBContext(DbContextOptions<RTMSDBContext> options) :
        base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
                .HasMany(u => u.UserLogins)
                .WithOne(ul => ul.User)
                .HasForeignKey(ul => ul.UserId);

        modelBuilder.Entity<User>()
                .HasMany(u => u.WorkoutTemplates)
                .WithOne(w => w.User)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
                .HasMany(u => u.Workouts)
                .WithOne(w => w.User)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserLogin>()
                .HasIndex(ul => new { ul.Provider, ul.ProviderKey })
                .IsUnique();

        modelBuilder.Entity<WorkoutTemplate>()
                .HasMany(w => w.Exercises)
                .WithOne()
                .HasForeignKey(e => e.WorkoutTemplateId)
                .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ExerciseTemplate>()
                .HasMany(e => e.Sets)
                .WithOne()
                .HasForeignKey(s => s.ExerciseTemplateId)
                .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Workout>()
                .HasMany(w => w.Exercises)
                .WithOne(e => e.Workout)
                .HasForeignKey(e => e.WorkoutId)
                .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Exercise>()
                .HasMany(e => e.Sets)
                .WithOne(s => s.Exercise)
                .HasForeignKey(s => s.ExerciseId)
                .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.UseIdentityColumns();
    }
    public DbSet<User> Users { get; set; }

    public DbSet<WorkoutTemplate> WorkoutTemplates { get; set; }
    public DbSet<ExerciseTemplate> ExerciseTemplates { get; set; }
    public DbSet<ExerciseSetTemplate> ExerciseSetTemplates { get; set; }

    public DbSet<Workout> Workouts { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<ExerciseSet> ExerciseSets { get; set; }
}
