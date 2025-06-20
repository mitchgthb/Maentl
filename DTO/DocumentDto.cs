﻿using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DocumentDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string FilePath { get; set; }

        public SourceSystem SourceSystem { get; set; }

        public DocumentType Type { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public string CreatedBy { get; set; }

        public int? WorkEntryId { get; set; }
        public string? WorkEntrySummary { get; set; }  // optional for UI

        public int? ProjectId { get; set; }
        public string? ProjectName { get; set; }       // optional for UI
    }
}
