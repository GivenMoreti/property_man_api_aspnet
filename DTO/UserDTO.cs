using System.ComponentModel.DataAnnotations;

namespace PropertyManApi.DTO
{
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