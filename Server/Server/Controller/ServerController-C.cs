using System;
using System.Runtime.InteropServices;
using Chat_CSLibrary;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Server.Controller
{
    public delegate IMensaje ClientMessageHandler(IMensaje m);
    public class ServerController
    {
        public ServerController()
        {
            var wss = new WebSocketServer(8001);

            // Add the Chat websocket service
            wss.AddWebSocketService("/chat", new Func<Chat>(CreateChat));

            // Start the server
            wss.Start();
        }

        ~ServerController()
        {
            //Serialize and put away the DB so it can be reloaded
        }

        private IMensaje Darn(IMensaje m)
        {
            throw new NotImplementedException();
        }
        private Chat CreateChat()
        {
            return new Chat(Darn);
        }

        public void SignIn(string name, string password)
        {
            throw new NotImplementedException();
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

        public void SendTextMessageMessage(string roomId, string username, DateTime time)
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
        private ClientMessageHandler _messageHandler;

        public Chat(ClientMessageHandler a)
        {
            _messageHandler = a;
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            if (e == null) throw new ArgumentNullException(nameof(e));

            //_messageHandler();

            Sessions.Broadcast("ahhhh");
        }
    }
}
