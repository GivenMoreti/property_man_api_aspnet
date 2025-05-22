namespace PropertyManApi.Models
{
    public class Tenant
    {
        public int TenantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public ICollection<Lease> Leases { get; set; }
    }

}