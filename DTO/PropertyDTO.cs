using System.ComponentModel.DataAnnotations;
using PropertyManApi.Enums;
using PropertyManApi.Models;

namespace PropertyManApi.DTO
{
    // PropertyDto.cs
    public class PropertyDTO : CreatePropertyDTO
    {
        public int PropertyId { get; set; }
        public ICollection<UnitDTO> Units { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
    }

    // CreatePropertyDto.cs
    public class CreatePropertyDTO
    {

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Property name is too long")]
        public string Name { get; set; }
        public AddressDTO Address { get; set; }
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Property description name is too long")]
        public string Description { get; set; }
        [Required]
        [Range(1, 1000)]
        public int NumberOfUnits { get; set; }
        public PropertyType PropertyType { get; set; }
    }

    // UpdatePropertyDto.cs
    public class UpdatePropertyDTO : CreatePropertyDTO;


}