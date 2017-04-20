using System;
using System.Runtime.InteropServices;
using Chat_CSLibrary;
using WebSocketSharp;
using WebSocketSharp.Server;
using Server.Model;

namespace Server.Controller
{
    public delegate IMensaje ClientMessageHandler(IMensaje m);
    public class ServerController
    {
        private ChatDb _chatDb;

        public ServerController(ChatDb db)
        {
            _chatDb = db;

            var wss = new WebSocketServer(8001);

            // Add the Chat websocket service
            wss.AddWebSocketService("/chat", new Func<Chat>(CreateChat));

            // Start the server
            wss.Start();
        }

        ~ServerController()
        {
            //Serialize and put away the DB so it can be reloaded on startup
        }

        private IMensaje ChatDelegate(IMensaje m)
        {
            SignIn("haufhun", "12345");

            throw new NotImplementedException();
        }
        private Chat CreateChat()
        {
            return new Chat(ChatDelegate);
        }

        public void SignIn(string name, string password)
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
