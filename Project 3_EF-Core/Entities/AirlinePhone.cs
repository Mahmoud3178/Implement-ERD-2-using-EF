using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3_EF_Core.Entities
{
    public class AirlinePhone
    {
        public int Id { get; set; }
        public string? PhoneNumber { get; set; }

        // FK
        public int? AirlineId { get; set; }
        public Airline? Airline { get; set; }
    }
}
