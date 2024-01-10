using System.ComponentModel.DataAnnotations;

namespace Web_API_for_scheduling.Models.entities
{
    public class Users
    {
        [Key]
        public Guid UserID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
