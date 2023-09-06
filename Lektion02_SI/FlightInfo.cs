using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lektion02_SI
{
    /// <summary>
    /// Information som Airline informationscentralen skal sende til flyselskaberne
    /// </summary>
    internal class FlightInfo : BaseEntity
    {
        public DateTime Boarding { get; set; }
        public int GateNo { get; set; }
        public FlightInfo(int flightNo, string destination, DateTime departure, DateTime boarding, int gateNo)
        {
            FlightNo = flightNo;
            Destination = destination;
            Departure = departure;
            Boarding = boarding;
            GateNo = gateNo;
        }

    }
}
