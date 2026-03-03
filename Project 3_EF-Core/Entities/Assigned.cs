using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3_EF_Core.Entities
{
    public class Assigned
    {
        public int AircraftId { get; set; }
        public Aircraft Aircraft { get; set; }

        public int RouteId { get; set; }
        public Route Route { get; set; }

        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }

        public decimal Price { get; set; }
        public int NumOfPassengers { get; set; }

        [NotMapped] // مش هعملو جدول دي عمليه حسابيه 
        public TimeSpan Duration => Arrival - Departure;
    }
}

