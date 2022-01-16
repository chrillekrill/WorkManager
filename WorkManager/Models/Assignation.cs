using System;
using System.Collections.Generic;

namespace WorkManager.Models
{
    public partial class Assignation
    {
        public long Id { get; set; }
        public long ProgrammerId { get; set; }
        public long AssignmentId { get; set; }

        public virtual Assignment Assignment { get; set; } = null!;
        public virtual Programmer Programmer { get; set; } = null!;
    }
}
