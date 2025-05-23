using System.ComponentModel.DataAnnotations;

namespace PropertyManApi.DTO
{
    public class LeaseDTO
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Required]
        public decimal RentAmount { get; set; }
        [Required]
        public bool IsActive { get; set; } = true;
        [Required]
        public int UnitId { get; set; }
        [Required]
        public int TenantId { get; set; }

    }
    public class LeaseSummaryDTO
    {
        public int LeaseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal RentAmount { get; set; }
        public bool IsActive { get; set; }
        public int TenantId { get; set; }
    }
    public class CreateLeaseDTO
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Required]
        public decimal RentAmount { get; set; }
        [Required]
        public int UnitId { get; set; }
        [Required]
        public int TenantId { get; set; }
    }
}