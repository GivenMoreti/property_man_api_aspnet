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
        public bool IsActive { get; set; }
        [Required]
        public int UnitId { get; set; }
        [Required]
        public int TenantId { get; set; }

    }
}