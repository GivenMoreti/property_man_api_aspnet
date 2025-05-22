namespace PropertyManApi.Models
{
    public class Lease
    {
        public int LeaseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal RentAmount { get; set; }
        public bool IsActive { get; set; }

        public int UnitId { get; set; }
        public Unit Unit { get; set; }

        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}