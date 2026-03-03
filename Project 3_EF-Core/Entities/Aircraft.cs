using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3_EF_Core.Entities
{
    public class Aircraft
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }

        public int AirlineId { get; set; }
        public Airline Airline { get; set; }

        public Crew Crew { get; set; }
        public ICollection<Assigned> AssignedRoutes { get; set; }
    }
}
