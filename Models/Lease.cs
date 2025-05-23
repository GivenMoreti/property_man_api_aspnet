namespace PropertyManApi.Models
{
    public class Lease
    {
        public int LeaseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal RentAmount { get; set; }
        public bool IsActive { get; set; }

        // Foreign key to Unit
        public int UnitId { get; set; }
        public Unit Unit { get; set; }

        // Foreign key to Tenant
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}