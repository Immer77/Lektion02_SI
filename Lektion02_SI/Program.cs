using System;
using System.Messaging;
namespace Lektion02_SI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MessageQueue messageQueue = null;
            if (!MessageQueue.Exists(@".\Private$\TestQueue")){
                MessageQueue.Create(@".\Private$\TestQueue");
            }
            
            messageQueue = new MessageQueue(@".\Private$\TestQueue");
            messageQueue.Send("Besked sendt til MSMQ", "Titel");

            Message message = messageQueue.Receive();
            Console.WriteLine(message.Body);
       
            Console.ReadLine();
        }
    }
}
