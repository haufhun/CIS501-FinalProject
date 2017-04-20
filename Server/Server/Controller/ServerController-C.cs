using System;
using System.Runtime.InteropServices;
using Chat_CSLibrary;
using WebSocketSharp;
using WebSocketSharp.Server;
using Server;

namespace Server.Controller
{
    public class ServerController
    {
        public ServerController()
        {
            var wss = new WebSocketServer(8001);

            // Add the Chat websocket service
            wss.AddWebSocketService<Chat>("/chat", new Func<Chat>(DoStuff));

            // Start the server
            wss.Start();
            
            //wss.OnMessage += (sender, e) => { if (MessageReceived != null) MessageReceived(e.Data);
        }

        ~ServerController()
        {
            
        }

        private void Darn()
        {
            
        }
        private Chat DoStuff()
        {
            return new Chat(Darn);
        }

        public void SignIn(string name, string password)
        {

        }

        public void AddContact(string name)
        {

        }

        public void RemoveContact(string name)
        {
            
        }
        public void CreateRoom()
        {

        }

        public void SendTextMessageMessage(string roomId, string username, DateTime time)
        {
            
        }

        public void AddContactToRoom(string name)
        {

        }
    }

    public class Chat : WebSocketBehavior
    {
        public Chat(Action a)
        {
            _handle = a;
        }

        private Action _handle;
        protected override void OnMessage(MessageEventArgs e)
        {
            if (e == null) throw new ArgumentNullException(nameof(e));
            _handle();
        }
    }
}
