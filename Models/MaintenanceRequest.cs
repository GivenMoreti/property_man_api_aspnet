using PropertyManApi.Enums;

namespace PropertyManApi.Models
{

    public class MaintenanceRequest
    {
        public int MaintenanceRequestId { get; set; }
        public string Description { get; set; }
        public DateTime RequestedDate { get; set; } = DateTime.UtcNow;
        public MaintenanceRequestStatus Status { get; set; } = MaintenanceRequestStatus.Open;

        public int UnitId { get; set; }
        public Unit Unit { get; set; }

        public int? AssignedToUserId { get; set; } // Optional: assigned staff
        public User AssignedToUser { get; set; }
    }
}