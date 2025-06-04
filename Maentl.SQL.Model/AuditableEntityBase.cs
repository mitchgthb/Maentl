using System.ComponentModel.DataAnnotations;

namespace Maentl.SQL.Model
{
    public abstract class AuditableEntityBase<TKey> : EntityBase<TKey>
    {
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(256)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        [MaxLength(256)]
        public string ModifiedBy { get; set; }
    }
}
