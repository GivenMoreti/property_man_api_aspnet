using System.ComponentModel.DataAnnotations;

namespace PropertyManApi.DTO
{

    public class UnitDTO
    {
        [Required]
        public string UnitNumber { get; set; }
        [Required]
        public decimal MonthlyRent { get; set; }
        [Required]
        public bool IsOccupied { get; set; }
        [Required]
        public int PropertyId { get; set; }

    }
}