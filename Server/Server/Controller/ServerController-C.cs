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

            if (room == null)
            {
                //Send error
                m = new Mensaje(Status.SendTextMessage, "The chat room no longer exists");
            }
            else
            {
                //We need to implement the GetAllContacts in the Class Library
                foreach(IUser user in room.GetAllContacts())
                {
                    if(!user.ContactInfo.Status)
                    {
                        //Notify all the other users that this user is offline
                        string sessionId = user.SessionId; //Need to add this. This is the Id associated with the user that we can use to communicate to them
                        room.RemoveUser(user.ContactInfo.Username); //Need to implement this method as well removes a user from a chat room

                    }
                }
                //Send 
                m = new Mensaje(room, msg);
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
            Sessions.SendTo(m.User.Id, message);
            //This is what I imagine the send  function will look like, we might need more -- Calvin
            //The Sessions.Broadcast will send it to ALL of the clients. We don't want this, we want to only send it to a specific client. This will help us with that
            //So, we may need to add a ClientId field to the Mensaje and the User classes so they can know that. 
                //Now, the question is, do we have the ClientId in the User class, or the Mensaje? We have it in the User then we HAVE to intialzie the
                //User object everytime we send a Mensaje between the two of us. Or, if the Mensaje has it, we use that, but then we have to make sure
                //that if we do send a User object, that the Ids are the same... 

            //An even better question is should the User know what their ClientId is? Orrrr should we just have a lookup based on the username what their ClientId is?
            //Then, we don't really have to worry about adding the ClientId to either... maybe. There's still a lot of variables. Tell me what you think.
        }
    }
}
