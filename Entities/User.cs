using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        [StringLength(maximumLength: 8, ErrorMessage = "too long password")]
        public string Password { get; set; }
        [EmailAddress(ErrorMessage = "Email not valid")]
        public string? Email { get; set; }
        public int UserId { get; set; }
    }
}