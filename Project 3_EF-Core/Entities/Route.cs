using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3_EF_Core.Entities
{
    public class Route
    {
    
            public int Id { get; set; }
            public string Origin { get; set; }
            public string Destination { get; set; }
            public double Distance { get; set; }
            public string Classification { get; set; }

            public ICollection<Assigned> AssignedAircrafts { get; set; }
        
    }
}
