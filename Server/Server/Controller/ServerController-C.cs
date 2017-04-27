using System;
using System.Collections.Generic;
using WebSocketSharp;
using WebSocketSharp.Server;
using Server.Model;
using Newtonsoft.Json;
using Chat_CSLibrary;
using static Server.Delegates;

namespace Server.Controller
{
    public class ServerController
    {
        /// <summary>
        /// The chat database holding the information about all Users and Chats.
        /// </summary>
        private readonly ChatDb _chatDb;

        /// <summary>
        /// The web socket server service. Only need to start and stop this service.
        /// </summary>
        private readonly WebSocketServer _wss;

        /// <summary>
        /// The delegate used to send a message to the Client.
        /// </summary>
        private SendMessageHandler _send;

        /// <summary>
        /// A list of event observers to update the event log.
        /// </summary>
        private readonly List<EventLogObserver> _eventObserver;

        /// <summary>
        /// A list of observers to update the database tab.
        /// </summary>
        private readonly List<Observer> _observers;

        /// <summary>
        /// Takes a Chat database in and constructs a new Server Controller. Creates the WebSocket Server and the Chat service.
        /// </summary>
        /// <param name="db">The chat database to be loaded.</param>
        public ServerController(ChatDb db)
        {
            _chatDb = db;
            _eventObserver = new List<EventLogObserver>();
            _observers = new List<Observer>();

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

        /// <summary>
        /// Deconstructor to turn off the web socket server.
        /// </summary>
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
        public void ChatDelegate(IMensaje m, string sessionId)
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
                    var otheruser = "";
                    foreach(var u in m.ChatRoom.Participants)
                    {
                        if (u.ContactInfo.Username != m.User.ContactInfo.Username)
                        {
                            otheruser = u.ContactInfo.Username;
                        }
                    }
                    CreateRoom(m.User.ContactInfo.Username, otheruser);
                    break;
                case State.RemoveContact:
                    RemoveContact(m.Contact.Username, m.User.ContactInfo.Username);
                    break;
                case State.SendTextMessage:
                    //SendTextMessage(m.ChatRoom.Id, m.Message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            SignalObserver();
        }

        /// <summary>
        /// Registers a new EventLogObserver in the list.
        /// </summary>
        /// <param name="o">An event log observer.</param>
        public void Register(EventLogObserver o)
        {
            _eventObserver.Add(o);
        }

        /// <summary>
        /// Registers a new Observer.
        /// </summary>
        /// <param name="o">The observer method to be updated. Should be a method from the view.</param>
        public void Register(Observer o)
        {
            _observers.Add(o);
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
        /// Calls the list of observers to update the database tab page.
        /// </summary>
        private void SignalObserver()
        {
            foreach(var o in _observers)
            {
                o();
            }
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
            Mensaje m;

            if (u == null)
            {
                _chatDb.AddUser(name, password, sessionId);

                m = new Mensaje(new User(new Contact(name, Status.Online), password, sessionId), true);

                SignalEventObserver(m);
            }
            else
            {
                if (u.IsValidPassword(password))
                {
                    u.ChangeSessionId(sessionId);

                    m = new Mensaje(u, false);
                    SignalEventObserver(m);
                }
                else
                {
                    m = new Mensaje(State.Login, "The password you entered is not valid");
                    SignalEventObserver(m);
                }
            }

            try { _send(m, sessionId); }
            catch { SignalEventObserver(new Mensaje(State.Login, "Could not login the user " + name)); }
        }

        /// <summary>
        /// Checks if the user to be added is null, if so sends an error to the Client, else puts both contacts into each other's lists.
        /// </summary>
        /// <param name="adder">The name of the user to be added.</param>
        /// <param name="toAdd">The name of the user that requested the add.</param>
        private void AddContact(string toAdd, string adder)
        {
            var a = _chatDb.LookupUser(adder);
            var b = _chatDb.LookupUser(toAdd);

            if (b == null)
            {
                var m = new Mensaje(State.AddContact, "This user does not exist");
                SignalEventObserver(m);
                try { _send(m, a.SessionId); } catch { SignalEventObserver(new Mensaje(State.AddContact, "The user " + a.ContactInfo.Username + " is not online.")); }
            }
            else
            {
                a.AddContact((Contact)b.ContactInfo);
                var m = new Mensaje(State.AddContact, b.ContactInfo, a);
                SignalEventObserver(m);
                try { _send(m, a.SessionId); } catch { SignalEventObserver(new Mensaje(State.AddContact, "The user " + a.ContactInfo.Username + " is not online.")); }

                b.AddContact((Contact)a.ContactInfo);
                var m2 = new Mensaje(State.AddContact, a.ContactInfo, b);
                SignalEventObserver(m2);

                if (b.ContactInfo.OnlineStatus == Status.Online)
                {
                    try { _send(m2, b.SessionId); } catch { SignalEventObserver(new Mensaje(State.AddContact, "The user " + b.ContactInfo.Username + " is not online.")); }
                }
            }
        }

        /// <summary>
        /// Removes two users from being in each other's contact list.
        /// </summary>
        /// <param name="remover">The user requesting the remove.</param>
        /// <param name="removed">The user to be removed.</param>
        private void RemoveContact(string removed, string remover)
        {
            var a = _chatDb.LookupUser(remover);
            var b = _chatDb.LookupUser(removed);

            if (b == null)
            {
                var m = new Mensaje(State.RemoveContact, "This user does not exist");
                SignalEventObserver(m);
                _send(m, a.SessionId);
            }
            else
            {
                a.RemoveContact((Contact)b.ContactInfo); 
                var m = new Mensaje(State.RemoveContact, b.ContactInfo, a);
                SignalEventObserver(m);
                try { _send(m, a.SessionId); } catch { SignalEventObserver(new Mensaje(State.RemoveContact, "The user " + a.ContactInfo.Username + " is not online.")); }

                b.RemoveContact((Contact)a.ContactInfo);
                var m2 = new Mensaje(State.AddContact, a.ContactInfo, b);
                SignalEventObserver(m2);

                if (b.ContactInfo.OnlineStatus == Status.Online)
                {
                    _send(m2, b.SessionId);
                }
                else
                {
                    SignalEventObserver(new Mensaje(State.AddContact, "The user " + b.ContactInfo.Username + " is not online."));
                }
            }
        }

        private void CreateRoom(string adder, string added)
        {
            User a = _chatDb.LookupUser(adder);
            User b = _chatDb.LookupUser(added);

            if (b == null)
            {
                _send(new Mensaje(State.OpenChat, "The user you want to chat with does not exist"), a.SessionId);
            }
            else if (b.ContactInfo.OnlineStatus == Status.Offline)
            {
                _send(new Mensaje(State.OpenChat, "The user you want to chat with is offline"), a.SessionId);
            }
            else {
                ChatRoom c = _chatDb.CreateRoom();
                _send(new Mensaje(c, b.ContactInfo), a.SessionId);
                _send(new Mensaje(c, a.ContactInfo), b.SessionId);
            }
        }

        private void SendTextMessage(string roomId, ITextMessage msg)
        {
            var room = _chatDb.LookupRoom(roomId);
            var activeIds = new List<string>();
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
                        var sessionId = u.SessionId; //Need to add this. This is the Id associated with the user that we can use to communicate to them
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
