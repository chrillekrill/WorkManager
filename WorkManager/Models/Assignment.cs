using System;
using System.Collections.Generic;

namespace WorkManager.Models
{
    public partial class Assignment
    {
        public Assignment()
        {
            Assignations = new HashSet<Assignation>();
        }

        public long Id { get; set; }
        public string Description { get; set; } = null!;
        public string AssignmentName { get; set; } = null!;

        public virtual ICollection<Assignation> Assignations { get; set; }
    }
}
