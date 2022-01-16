using System;
using System.Collections.Generic;

namespace WorkManager.Models
{
    public partial class Programmer
    {
        public Programmer()
        {
            Assignations = new HashSet<Assignation>();
            Contacts = new HashSet<Contact>();
        }

        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public virtual ICollection<Assignation> Assignations { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
