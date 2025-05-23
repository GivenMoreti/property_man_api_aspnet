using System.ComponentModel.DataAnnotations;
using PropertyManApi.Models;

namespace PropertyManApi.DTO
{

    // Every unit belongs to a certain Property.
    public class UnitDTO
    {
        [Required]
        public string UnitNumber { get; set; }
        [Required]
        public decimal MonthlyRent { get; set; }
        [Required]
        public bool IsOccupied { get; set; } = false;
        [Required]
        public int PropertyId { get; set; }
        public ICollection<Lease> Leases { get; set; }
        public ICollection<MaintenanceRequest> MaintenanceRequests { get; set; }

    }

    public class CreateUnitDTO : UnitDTO;
}