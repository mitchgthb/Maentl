using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProjectDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string OwnerEmail { get; set; }

        public ProjectStatus Status { get; set; }

        public DateTime? Deadline { get; set; }
    }
}
