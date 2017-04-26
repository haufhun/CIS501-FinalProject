using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat_CSLibrary;
using Server.Model;

namespace Server
{
    public class Delegates
    {
        //The delegate that will update the GUI application with information from the server
        public delegate void EventLogObserver(IMensaje m);
        //The delegate that will handle a user interaction
        public delegate void InputHandler(IMensaje m, string s);

        //Delegate used to call the controller from the Chat WebSocketBehavior class
        public delegate void ClientMessageHandler(IMensaje m, string sessionId);
        //Delegate used to send a message back to the appropriate user
        public delegate void SendMessageHandler(IMensaje m, string sessionId);

    }
}
