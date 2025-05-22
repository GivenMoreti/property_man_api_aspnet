using System.ComponentModel.DataAnnotations;
using PropertyManApi.Enums;
using PropertyManApi.Models;

namespace PropertyManApi.DTO
{
    // PropertyDto.cs
    public class PropertyDTO
    {
        public int PropertyId { get; set; }
        public string Name { get; set; }
        public AddressDTO Address { get; set; }
        public string Description { get; set; }
        public int NumberOfUnits { get; set; }
        public PropertyType PropertyType { get; set; }
        public ICollection<UnitDTO> Units { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
    }

    // CreatePropertyDto.cs
    public class CreatePropertyDTO
    {
     
        public string Name { get; set; }

        
        public AddressDTO Address { get; set; }

        
        public string Description { get; set; }

        
        public int NumberOfUnits { get; set; }

        
        public PropertyType PropertyType { get; set; }
    }

    // UpdatePropertyDto.cs
    public class UpdatePropertyDTO : CreatePropertyDTO;


}