using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Lektion02_SI
{
    /// <summary>
    /// Simple router taget ud fra EIP bogen
    /// </summary>
    internal class AirportRouter
    {
        /// <summary>
        /// Har 1 inqueue channel og 2 out
        /// </summary>
        protected MessageQueue Inqueue;
        protected MessageQueue OutqueueOne;
        protected MessageQueue OutqueueTwo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inqueue"> Queue beskeden først kommer ind på inden den routes ud på enten queue 1 eller 2</param>
        /// <param name="outqueueOne"></param>
        /// <param name="outqueueTwo"></param>
        public AirportRouter(MessageQueue inqueue, MessageQueue outqueueOne, MessageQueue outqueueTwo)
        {
            Inqueue = inqueue;
            OutqueueOne = outqueueOne;
            OutqueueTwo = outqueueTwo;

            ///
            /// Denne linje tilføjer en hændelseshåndterer (event handler) til ReceiveCompleted-begivenheden på objektet inqueue. 
            /// ReceiveCompleted er en begivenhed, der udløses, når en besked er færdig med at blive modtaget. 
            /// Når begivenheden udløses, vil den kalde metoden OnMessage, som er defineret et sted i din kode. 
            /// Med andre ord forbinder denne linje begivenheden ReceiveCompleted med metoden OnMessage, 
            /// så når en besked er færdig med at blive modtaget, vil metoden OnMessage blive udført.
            inqueue.ReceiveCompleted += new ReceiveCompletedEventHandler(OnMessage);

            /// Denne linje starter en asynkron operation for at begynde at modtage en besked fra inqueue. 
            /// Dette betyder, at dit system vil begynde at lytte efter beskeder i køen inqueue. 
            /// Den præcise funktionalitet af metoden BeginReceive afhænger af den type beskedkø eller kommunikationsmekanisme, 
            /// du bruger i dit system. 
            /// Den kan for eksempel initiere en asynkron operation, der lytter efter beskeder og starter behandlingen af dem.
            inqueue.BeginReceive();
        }

        private void OnMessage(Object source, ReceiveCompletedEventArgs asyncResult)
        {
            MessageQueue mq = (MessageQueue)source;
            Message message = mq.EndReceive(asyncResult.AsyncResult);
            
            if (message.Label.Split(' ')[0] is "SAS")
            {
                OutqueueOne.Send(message);

            }
            else if(message.Label.Split(' ')[0] is "KLM")
            {
                OutqueueTwo.Send(message);
            }

            mq.BeginReceive();
        }
    }
}
