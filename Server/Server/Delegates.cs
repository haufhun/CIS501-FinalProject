using Chat_CSLibrary;

namespace Server
{
    public class Delegates
    {
        //The delegate that will update the GUI application with information from the server
        public delegate void EventLogObserver(IMensaje m);
        //Observer to update the information displayed in the Database tab.
        public delegate void Observer();
        //The delegate that will handle a user interaction
        public delegate void InputHandler(IMensaje m, string s);

        //Delegate used to call the controller from the Chat WebSocketBehavior class
        public delegate void ClientMessageHandler(IMensaje m, string sessionId);
        //Delegate used to send a message back to the appropriate user
        public delegate void SendMessageHandler(IMensaje m, string sessionId);

    }
}
