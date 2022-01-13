using System;
using System.Collections.Generic;

namespace WorkManager.Models
{
    public partial class Programmer
    {
        public Programmer()
        {
            Assignments = new HashSet<Assignment>();
            Contacts = new HashSet<Contact>();
        }

        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
