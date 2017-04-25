using System;
using System.Collections.Generic;
using WebSocketSharp;
using WebSocketSharp.Server;
using Server.Model;
using Newtonsoft.Json;
using Chat_CSLibrary;
using Server;
using static Server.Delegates;

namespace Server.Controller
{
    //Delegate used to call the controller from the Chat WebSocketBehavior class
    public delegate void ClientMessageHandler(IMensaje m, string sessionId);
    //Delegate used to send a message back to the appropriate user
    public delegate void SendMessageHandler(IMensaje m, string sessionId);

    public class ServerController
    {
        private readonly ChatDb _chatDb;

        private readonly WebSocketServer _wss;

        private SendMessageHandler _send;

        private List<EventLogObserver> _eventObserver;

        /// <summary>
        /// Takes a Chat database in and constructs a new Server Controller. Creates the WebSocket Server and the Chat service.
        /// </summary>
        /// <param name="db">The chat database to be loaded.</param>
        public ServerController(ChatDb db)
        {
            _chatDb = db;
            _eventObserver = new List<EventLogObserver>();

            _wss = new WebSocketServer(8022);

            // Add the Chat websocket service
            _wss.AddWebSocketService("/chat", CreateChat);

            // Start the server
            _wss.Start();
        }

        /// <summary>
        /// Factory method. Used to construct the chat for the WebSocketBehavior. Sets up the delegates for both receive and send between the Controller and the Chat.
        /// </summary>
        /// <returns>A new instance of the Chat class.</returns>
        private Chat CreateChat()
        {
            var c = new Chat(ChatDelegate);
            _send = c.Send;
            return c;
        }

        ~ServerController()
        {
            //Need to serialize and put away the DB so it can be reloaded on startup
            _wss.Stop();
        }

        /// <summary>
        /// Delegate that will be called on a receive from the Chat imitating the client.
        /// </summary>
        /// <param name="m">The Mensaje object sent from the Client.</param>
        /// <param name="sessionId">The session id of the Client.</param>
        private void ChatDelegate(IMensaje m, string sessionId)
        {
            SignalEventObserver(m);

            switch (m.MyState)
            {
                case State.AddContact:
                    AddContact(m.Contact.Username, m.User.ContactInfo.Username);
                    break;
                case State.AddContactToChat:
                    break;
                case State.Login:
                    //Must cast this to our User object so as to access the password.
                    Login(m.User.ContactInfo.Username, ((User)m.User).Password, sessionId);
                    break;
                case State.Logout:
                    break;
                case State.OpenChat:
                    break;
                case State.RemoveContact:
                    break;
                case State.SendTextMessage:
                    //SendTextMessage(m.ChatRoom.Id, m.Message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Calls the list of event log observers and displays to the log the contents of a Mensaje.
        /// </summary>
        /// <param name="m">The Mensaje object.</param>
        private void SignalEventObserver(IMensaje m)
        {
            foreach(EventLogObserver o in _eventObserver)
            {
                o(m);
            }
        }

        /// <summary>
        /// Registers a new EventLogObserver in the list.
        /// </summary>
        /// <param name="o">An event log observer.</param>
        public void RegisterEventLog(EventLogObserver o)
        {
            _eventObserver.Add(o);
        }

        /// <summary>
        /// Looks up if a user exists, creating a new user if needed, or validates the password sent in.
        /// </summary>
        /// <param name="name">The name of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <param name="sessionId">The session id of the client.</param>
        private void Login(string name, string password, string sessionId)
        {
            var u = _chatDb.LookupUser(name);

            if (u == null)
            {
                _chatDb.AddUser(name, password, sessionId);

                var m = new Mensaje(new User(new Contact(name, Status.Online), password, sessionId), true);

                SignalEventObserver(m);
                _send(m, sessionId );
            }
            else
            {
                if (u.IsValidPassword(password))
                {
                    u.ChangeSessionId(sessionId);

                    var m = new Mensaje(u, false);
                    SignalEventObserver(m);
                    _send(m,sessionId);
                }
                else
                {
                    var m = new Mensaje(State.Login, "The password you entered is not valid");
                    SignalEventObserver(m);
                    _send(m,sessionId);
                }
            }
        }

        /// <summary>
        /// Checks if the user to be added is null, if so sends an error to the Client, else puts both contacts into each other's lists.
        /// </summary>
        /// <param name="adder">The name of the user to be added.</param>
        /// <param name="toAdd">The name of the user that requested the add.</param>
        public void AddContact(string adder, string toAdd)
        {
            User a = _chatDb.LookupUser(adder);
            User b = _chatDb.LookupUser(toAdd);

            if (b == null)
            {
                var m = new Mensaje(State.AddContact, "This user does not exist");
                SignalEventObserver(m);
                _send(m, a.SessionId);
            }
            else
            {
                a.AddContact(b.ContactInfo);
                var m = new Mensaje(State.AddContact, b.ContactInfo, a);
                SignalEventObserver(m);
                _send(m, a.SessionId);

                b.AddContact(a.ContactInfo);
                var m2 = new Mensaje(State.AddContact, a.ContactInfo, b);
                SignalEventObserver(m2);

                if (b.ContactInfo.OnlineStatus == Status.Online)
                {
                    _send(m2, b.SessionId);
                }
            }
        }

        public void RemoveContact(string name)
        {
            throw new NotImplementedException();
        }
        public void CreateRoom()
        {
            throw new NotImplementedException();
        }

        public void SendTextMessage(string roomId, ITextMessage msg)
        {
            ChatRoom room = _chatDb.LookupRoom(roomId);
            List<string> activeIds = new List<string>();
            IMensaje m = null;

            if (room == null)
            {
                //Send error
                //m = new Mensaje(State.SendTextMessage, "The chat room no longer exists");
            }
            else
            {
                //We need to implement the GetAllUsers in the Class Library
                foreach (var user in room.Participants)
                {
                    var u = (User) user;
                    if (u.ContactInfo.OnlineStatus == Status.Offline)
                    {
                        //Notify all the other users that this user is offline
                        string sessionId = u.SessionId; //Need to add this. This is the Id associated with the user that we can use to communicate to them
                        //room.RemoveUser(u.ContactInfo.Username); //Need to implement this method as well removes a user from a chat room
                    }
                    else
                    {
                        activeIds.Add(u.SessionId);
                    }
                }

                m = new Mensaje(room, msg);
            }

            //_send(m, activeIds);
        }

        public void AddContactToRoom(string name)
        {
            throw new NotImplementedException();
        }
    }

    public class Chat : WebSocketBehavior
    {
        private readonly ClientMessageHandler _receive;

        public Chat(ClientMessageHandler a)
        {
            _receive = a;
        }

        protected override void OnOpen()
        {

        }

        protected override void OnMessage(MessageEventArgs e)
        {
            if (e == null) throw new ArgumentNullException(nameof(e));

            //Deserialize this first, don't just pass a new instance...
            var m = JsonConvert.DeserializeObject<Mensaje>(e.Data);
            _receive(m, ID);
        }

        public void Send(IMensaje m, string sessionId)
        {
            string message = JsonConvert.SerializeObject(m);

            Sessions.SendTo(sessionId, message);
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
