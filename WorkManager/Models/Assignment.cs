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

        public string GetAllEmployees()
        {
            string employees = string.Empty;
            for (int i = 0; i < Assignations.Count; i++)
            {
                if (i < Assignations.Count - 1)
                {
                    employees += $"{Assignations.ToList()[i].Programmer.FullName}, ";
                }
                else
                {
                    employees += $"{Assignations.ToList()[i].Programmer.FullName}";
                }
            }
            return employees;
        }
    }
}
