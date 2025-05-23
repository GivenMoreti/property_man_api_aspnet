using System.ComponentModel.DataAnnotations;
using PropertyManApi.Enums;

namespace PropertyManApi.DTO
{
    public class UserDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        // public Role Role { get; set; } = Role.Tenant;
        // public string PasswordHash { get; set; }

        public ICollection<MaintenanceRequestDTO> AssignedRequests { get; set; }
    }
    public class LoginUserDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
    }


    public class RegisterUserDTO : LoginUserDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}