using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3_EF_Core.Entities
{
    public class Crew
    {
        public int AircraftId { get; set; } // PK + FK

        public string MajPilot { get; set; }
        public string AssisPilot { get; set; }
        public string Host1 { get; set; }
        public string Host2 { get; set; }

        public Aircraft Aircraft { get; set; }
    }
}
