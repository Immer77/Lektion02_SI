using System;
using System.Messaging;
using System.Text.Json;

namespace Lektion02_SI
{
    internal class AirportInfoCenter
    {
        static void Main(string[] args)
        {
            AirLineInformation SAS = new AirLineInformation("SAS",DateTime.Now,DateTime.Now,22,"Maldives",DateTime.Now);
            string bodyFormatSAS = JsonSerializer.Serialize<AirLineInformation>(SAS);
            AirLineInformation KLM = new AirLineInformation("KLM", DateTime.Now, DateTime.Now, 24, "Denmark", DateTime.Now);
            string bodyFormatKLM = JsonSerializer.Serialize<AirLineInformation>(KLM);
            MessageQueue AirportInfo = null;
            MessageQueue SASQueue = null;
            MessageQueue KLMQueue = null;
            if (!MessageQueue.Exists(@".\Private$\AirportInfo"))
            {
                MessageQueue.Create(@".\Private$\AirportInfo");
            }

            if (!MessageQueue.Exists(@".\Private$\SASInformation"))
            {
                MessageQueue.Create(@".\Private$\SASInformation");
            }

            if (!MessageQueue.Exists(@".\Private$\KLMInformation"))
            {
                MessageQueue.Create(@".\Private$\KLMInformation");
            }

            AirportInfo = new MessageQueue(@".\Private$\AirportInfo");
            SASQueue = new MessageQueue(@".\Private$\SASInformation");
            KLMQueue = new MessageQueue(@".\Private$\KLMInformation");
            
            SASQueue.Send(bodyFormatSAS, $"{SAS.AirlineCompany} FlightNo {SAS.FlightNo} Destination: {SAS.Destination}");
            KLMQueue.Send(bodyFormatKLM, $"{KLM.AirlineCompany} FlightNo {KLM.FlightNo} Destination: {KLM.Destination}");


            AirportRouter router = new AirportRouter(AirportInfo, SASQueue, KLMQueue);
            FlightInfo flight = new FlightInfo(22, "LAX", DateTime.Now, DateTime.Now, 33); // Ret så det passer med at vi kan sende det til den nødvendige fly.
            string flightBody = JsonSerializer.Serialize<FlightInfo>(flight);
            AirportInfo.Send(flightBody);
            Console.ReadLine();
        }
    }
}
