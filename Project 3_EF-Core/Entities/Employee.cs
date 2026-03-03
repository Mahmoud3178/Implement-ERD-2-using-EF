using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3_EF_Core.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Position { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }

        // FK
        public int AirlineId { get; set; }
        public Airline Airline { get; set; }

        // Navigation
        public ICollection<EmployeeQualification> Qualifications { get; set; }
    }
}
