using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RTMS.CoreBusiness
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }  // Internal system ID

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        // Navigation property for external logins
        public ICollection<UserLogin> UserLogins { get; set; }
        public ICollection<WorkoutTemplate> WorkoutTemplates { get; set; }
        public ICollection<Workout> Workouts { get; set; }
    }
}
