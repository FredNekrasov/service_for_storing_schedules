using Microsoft.EntityFrameworkCore;

namespace Web_API_for_scheduling.Models.entities
{
    [PrimaryKey(nameof(UserID))]
    public class Users
    {
        public int UserID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
