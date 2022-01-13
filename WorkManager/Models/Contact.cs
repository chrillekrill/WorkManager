using System;
using System.Collections.Generic;

namespace WorkManager.Models
{
    public partial class Contact
    {
        public long Id { get; set; }
        public long? ContactId { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual Programmer? ContactNavigation { get; set; }
    }
}
