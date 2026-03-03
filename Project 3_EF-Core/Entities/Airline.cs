using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3_EF_Core.Entities
{
    public class Airline
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? ContactPerson { get; set; }

        // Navigation Property
        public ICollection<AirlinePhone>? Phones { get; set; }

         public ICollection<Employee> Employees { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<Aircraft> Aircrafts { get; set; }
        
    }
}
