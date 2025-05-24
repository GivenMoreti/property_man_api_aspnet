using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyManApi.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadedAt { get; set; }

        public int? PropertyId { get; set; }
        public Property Property { get; set; }

        [ForeignKey(nameof(Lease))]
        public int? LeaseId { get; set; }
        public Lease Lease { get; set; }

        [ForeignKey(nameof(Tenant))]
        public int? TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }

}