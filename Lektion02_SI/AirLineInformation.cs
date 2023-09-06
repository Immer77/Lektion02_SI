using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lektion02_SI
{
    /// <summary>
    /// Airline informations klasse som airline companies skal sende til informationsportalen som i den her situation er
    /// airline information portal
    /// </summary>
    internal class AirLineInformation : BaseEntity
    {
        /// <summary>
        /// Attributter med nødvendige information givet ud fra opgaven
        /// </summary>
        public string AirlineCompany { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime CheckIn { get; set; }

        public AirLineInformation(string airlineCompany, DateTime departure, DateTime arrival, int flightNo, string destination, DateTime checkIn)
        {
            AirlineCompany = airlineCompany;
            Departure = departure;
            Arrival = arrival;
            FlightNo = flightNo;
            Destination = destination;
            CheckIn = checkIn;
        }
    }
}
