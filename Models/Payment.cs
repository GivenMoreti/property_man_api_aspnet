using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyManApi.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public DateTime DatePaid { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } // E.g., Bank Transfer
        public bool IsSuccessful { get; set; }

        [ForeignKey(nameof(Lease))]
        public int LeaseId { get; set; }
        public Lease Lease { get; set; }
    }
}