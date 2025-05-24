using System.ComponentModel.DataAnnotations;
using PropertyManApi.Enums;

namespace PropertyManApi.DTO
{
    public class MaintenanceRequestDTO : CreateMaintenanceRequestDTO
    {
        public int MaintenanceRequestId { get; set; }

    }

    public class CreateMaintenanceRequestDTO
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public int UnitId { get; set; }
        [Required]
        public int? AssignedToUserId { get; set; } // Optional: assigned staff
    }

    public class UpdateMaintenanceRequestDTO : CreateMaintenanceRequestDTO;

}