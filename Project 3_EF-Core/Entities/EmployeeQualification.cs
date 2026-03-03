using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3_EF_Core.Entities
{
    public class EmployeeQualification
    {
        public int Id { get; set; }
        public string Qualification { get; set; }

        // FK
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
