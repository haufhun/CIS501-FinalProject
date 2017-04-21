using System;
using System.Runtime.InteropServices;
using Chat_CSLibrary;
using WebSocketSharp;
using WebSocketSharp.Server;
using Server.Model;
using Newtonsoft.Json;

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
            switch (m.MyStatus)
            {
                case Status.AddContact:

                    break;
                case Status.AddContactToChat:
                    break;
                case Status.Login:
                    break;
                case Status.Logout:
                    break;
                case Status.OpenChat:
                    break;
                case Status.RemoveContact:
                    break;
                case Status.SendTextMessage:
                    SendTextMessage(m.ChatRoom.Id, m.Message);
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

        //public void SendTextMessage(string roomId, string username, DateTime time)
        public void SendTextMessage(string roomId, ITextMessage msg)
        {
            IChatRoom room = _chatDb.LookupRoom(roomId);
            IMensaje m = null;
            if (room != null)
            {
                m = new Mensaje(room, msg);
            }
            else
            {
                m = new Mensaje(Status.SendTextMessage, "The chat room no longer exists");
            }
            _send(m);
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
            IMensaje m = new Mensaje();
            _receive(m);
        }

        public void Send(IMensaje m)
        {
            string message = JsonConvert.SerializeObject(m);
            Sessions.Broadcast(message);
            //This is what I imagine the send  function will look like, we might need more -- Calvin
        }
    }
}
