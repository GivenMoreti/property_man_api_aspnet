using System.ComponentModel.DataAnnotations.Schema;
using PropertyManApi.Enums;

namespace PropertyManApi.Models
{

    public class MaintenanceRequest
    {
        public int MaintenanceRequestId { get; set; }
        public string Description { get; set; }
        public DateTime RequestedDate { get; set; } = DateTime.UtcNow;
        public MaintenanceRequestStatus Status { get; set; } = MaintenanceRequestStatus.Open;

        [ForeignKey(nameof(Unit))]
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        [ForeignKey(nameof(User))]
        public int? AssignedToUserId { get; set; } // Optional: assigned staff
        public User AssignedToUser { get; set; }
    }
}