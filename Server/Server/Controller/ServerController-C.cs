using System;
using System.Runtime.InteropServices;
using Chat_CSLibrary;
using WebSocketSharp;
using WebSocketSharp.Server;
using Server.Model;

namespace Server.Controller
{
    //Delegate used to call the controller from the Chat WebSocketBehavior class
    public delegate void MensajeHandler(IMensaje m);

    public class ServerController
    {
        private ChatDb _chatDb;

        private MensajeHandler _send;

        public ServerController(ChatDb db)
        {
            _chatDb = db;

            var wss = new WebSocketServer(8001);

            // Add the Chat websocket service
            wss.AddWebSocketService("/chat", CreateChat);

            // Start the server
            wss.Start();
        }

        ~ServerController()
        {
            //Serialize and put away the DB so it can be reloaded on startup
        }

        private void ChatDelegate(IMensaje m)
        {
            switch (m.MyState)
            {
                case State.AddContact:

                    break;
                case State.AddContactToChat:
                    break;
                case State.Login:
                    break;
                case State.Logout:
                    break;
                case State.OpenChat:
                    break;
                case State.RemoveContact:
                    break;
                case State.SendTextMessage:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            SignIn("haufhun", "12345");

            throw new NotImplementedException();
        }
        private Chat CreateChat()
        {
            var c = new Chat(ChatDelegate);
            _send = c.Send;
            return c;
        }

        private void SignIn(string name, string password)
        {
            
        }

        public void AddContact(string name)
        {
            throw new NotImplementedException();
        }

        public void RemoveContact(string name)
        {
            throw new NotImplementedException();
        }
        public void CreateRoom()
        {
            throw new NotImplementedException();
        }

        public void SendTextMessage(string roomId, string username, DateTime time)
        {
            throw new NotImplementedException();
        }

        public void AddContactToRoom(string name)
        {
            throw new NotImplementedException();
        }
    }

    public class Chat : WebSocketBehavior
    {
        private readonly MensajeHandler _receive;

        public Chat(MensajeHandler a)
        {
            _receive = a;
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            if (e == null) throw new ArgumentNullException(nameof(e));
            //Deserialize this first, don't just pass a new instance...
            IMensaje m = null;
            _receive(m);
        }

        public void Send(IMensaje m)
        {
            Sessions.Broadcast("");

            throw new NotImplementedException();
        }
    }
}
