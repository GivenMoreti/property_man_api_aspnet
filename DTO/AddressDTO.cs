using System.ComponentModel.DataAnnotations;

namespace PropertyManApi.DTO
{
    public class AddressDTO
    {
        public int AddressId { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
    }

    public class CreateAddressDTO
    {
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string Street { get; set; }
    }

}