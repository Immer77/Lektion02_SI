using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lektion02_SI
{
    internal abstract class BaseEntity
    {
        public DateTime Departure { get; set; }
        public string Destination { get; set; }

        public int FlightNo { get; set; }
    }
}
