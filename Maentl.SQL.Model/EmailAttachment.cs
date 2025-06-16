using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maentl.SQL.Model
{
    public class EmailAttachment : AuditableEntityBase<Guid>
    {
        [Required]
        [StringLength(255)]
        public string FileName { get; set; }

        [Required]
        [StringLength(100)]
        public string ContentType { get; set; }

        public int FileSize { get; set; }

        [Required]
        public Guid EmailActivityId { get; set; }

        [ForeignKey("EmailActivityId")]
        public EmailActivity EmailActivity { get; set; }
    }
}
