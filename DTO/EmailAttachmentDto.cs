using Maentl.SQL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmailAttachmentDto
    {
        public string FileName { get; set; }
        public byte[] ContentBytes { get; set; } // for upload to SharePoint
        public string ContentType { get; set; }
        public int FileSize { get; set; }
    }
}
