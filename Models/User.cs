using PropertyManApi.Enums;

namespace PropertyManApi.Models
{

    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; } = Role.Tenant;
        public string PasswordHash { get; set; }

        public ICollection<MaintenanceRequest> AssignedRequests { get; set; }
    }
}