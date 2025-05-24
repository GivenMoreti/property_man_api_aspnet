namespace PropertyManApi.Models
{
    public class Unit
    {
        public int UnitId { get; set; }
        public string UnitNumber { get; set; }
        public decimal MonthlyRent { get; set; }
        public bool IsOccupied { get; set; }
        
        public int PropertyId { get; set; }
        public Property Property { get; set; }

        public virtual IList<Lease> Leases { get; set; } = new List<Lease>();
        public virtual IList<MaintenanceRequest> MaintenanceRequests { get; set; } = new List<MaintenanceRequest>();
    }
    
}