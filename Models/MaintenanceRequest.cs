namespace PropertyManApi.Models
{

    public class MaintenanceRequest
    {
        public int MaintenanceRequestId { get; set; }
        public string Description { get; set; }
        public DateTime RequestedDate { get; set; }
        public string Status { get; set; } // E.g., Open, In Progress, Completed

        public int UnitId { get; set; }
        public Unit Unit { get; set; }

        public int? AssignedToUserId { get; set; } // Optional: assigned staff
        public User AssignedToUser { get; set; }
    }
}