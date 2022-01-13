using System;
using System.Collections.Generic;

namespace WorkManager.Models
{
    public partial class Assignment
    {
        public long Id { get; set; }
        public long? EmployeeId { get; set; }
        public string? Description { get; set; }

        public virtual Programmer? Employee { get; set; }
    }
}
