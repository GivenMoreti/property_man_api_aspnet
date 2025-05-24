using System.ComponentModel.DataAnnotations;

namespace PropertyManApi.DTO
{
    public class TenantDTO : CreateTenantDTO
    {
        public int TenantId { get; set; }
        [Required]
        public ICollection<LeaseDTO> Leases { get; set; }
    }

    public class CreateTenantDTO
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Name is too long")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Last name is too long")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(maximumLength: 50, ErrorMessage = "Email is too long")]
        public string Email { get; set; }
        [Required]
        [StringLength(maximumLength: 10, ErrorMessage = "Phone is too long")]
        public string Phone { get; set; }
    }

    public class UpdateTenantDTO : CreateTenantDTO;

}