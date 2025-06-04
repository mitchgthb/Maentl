using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string DisplayName { get; set; }

        public UserRole Role { get; set; }

        public bool IsActive { get; set; }

        public DateTime? LastSynced { get; set; }  // Optional, for audit/logging
    }
}
