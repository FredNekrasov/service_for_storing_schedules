using Microsoft.EntityFrameworkCore;

namespace API_for_mobile_app.model.entities
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
