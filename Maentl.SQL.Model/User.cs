using Enums;
using System.ComponentModel.DataAnnotations;

namespace Maentl.SQL.Model
{
    public class User : EntityBase<int>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string DisplayName { get; set; }

        [Required]
        public UserRole Role { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigation properties
        public ICollection<WorkEntry> WorkEntries { get; set; } = new List<WorkEntry>();

        public ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}
