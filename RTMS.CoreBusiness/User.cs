using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RTMS.CoreBusiness
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }  // Internal User ID
        public string Auth0Id { get; set; } // Store the Auth0 UserId

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public ICollection<WorkoutTemplate> WorkoutTemplates { get; set; }
        public ICollection<Workout> Workouts { get; set; }
    }
}
