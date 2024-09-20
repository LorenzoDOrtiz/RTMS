namespace RTMS.Web.Dtos
{
    public class Auth0UserDto
    {
        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public List<string> Roles { get; set; }

        public IEnumerable<string> SelectedRoleIds { get; set; } // The role selected by the user


    }
}
