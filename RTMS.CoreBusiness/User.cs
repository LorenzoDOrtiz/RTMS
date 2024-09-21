using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RTMS.CoreBusiness
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Auth0Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        [Required]
        public string Email { get; set; }

        public ICollection<WorkoutTemplate> WorkoutTemplates { get; set; }
        public ICollection<Workout> Workouts { get; set; }
        public ICollection<ClientWorkoutTemplate> ClientWorkoutTemplates { get; set; } = new List<ClientWorkoutTemplate>();

    }
}
