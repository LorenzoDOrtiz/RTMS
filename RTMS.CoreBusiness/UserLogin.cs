using System.ComponentModel.DataAnnotations;

namespace RTMS.CoreBusiness
{
    public class UserLogin
    {
        public int Id { get; set; }  // Primary key for UserLogin

        [Required]
        public string Provider { get; set; }  // e.g., "Google", "Facebook", "GitHub"

        [Required]
        public string ProviderKey { get; set; }  // e.g., "google-oauth2|105291924524340186405"

        // Foreign key to the User entity
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
