using Chat_CSLibrary;

namespace Server
{
    /// <summary>
    /// A list of all the delegates to be used in the system.
    /// </summary>
    public class Delegates
    {
        /// <summary>
        /// The delegate that will update the GUI application with information from the server
        /// </summary>
        /// <param name="m">The Mensaje object desired to be logged.</param>
        /// <param name="s">The status of the Mensjae, whether it be Send, Receive, or Internal. If there is an error in sending to a client, it is an internal error.</param>
        public delegate void EventLogObserver(IMensaje m, LogStatus s);
        /// <summary>
        /// //Observer to update the information displayed in the Database tab.
        /// </summary>
        public delegate void Observer();
        /// <summary>
        /// Handles input from the ServerForm GUI. Only to be used in testing mode.
        /// </summary>
        /// <param name="m">The Mensaje object to send to the ServerController.</param>
        /// <param name="sessionId">The session id. A fake parameter. Could be null.</param>
        public delegate void InputHandler(IMensaje m, string sessionId);

        /// <summary>
        /// Delegate used to call the controller from the Chat WebSocketBehavior class
        /// </summary>
        /// <param name="m">The Mensaje received from the Client.</param>
        /// <param name="sessionId">The session id of the Client that sent the Mensaje object.</param>
        public delegate void ClientMessageHandler(IMensaje m, string sessionId);
        /// <summary>
        /// Delegate used to send a message back to the appropriate user
        /// </summary>
        /// <param name="m">The Mensaje object to send to the Client</param>
        /// <param name="sessionId">The session id of the client to send to.</param>
        public delegate void SendMessageHandler(IMensaje m, string sessionId);

    }

    /// <summary>
    /// The Status of an Event Log, used in the EventLogObserver.
    /// </summary>
    public enum LogStatus
    {
        Receive,
        Send,
        Internal
    }
}
