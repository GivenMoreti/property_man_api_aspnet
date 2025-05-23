using System.ComponentModel.DataAnnotations;

namespace PropertyManApi.DTO
{
    public class TenantDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public ICollection<LeaseDTO> Leases { get; set; }
    }

    public class CreateTenantDTO : TenantDTO;


}