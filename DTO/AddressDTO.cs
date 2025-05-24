using System.ComponentModel.DataAnnotations;

namespace PropertyManApi.DTO
{
    public class AddressDTO : CreateAddressDTO
    {
        public int AddressId { get; set; }
    }

    public class CreateAddressDTO
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "state is too long")]
        public string State { get; set; }
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "country is too long")]
        public string Country { get; set; }
        [Required]
        [StringLength(maximumLength: 10, ErrorMessage = "state is too long")]
        public string ZipCode { get; set; }
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "street is too long")]
        public string Street { get; set; }
    }

    public class UpdateAddressDTO : CreateAddressDTO
    {

    }

}