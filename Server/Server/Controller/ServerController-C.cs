﻿using System;
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
        internal void ChatDelegate(IMensaje m, string sessionId)
        {
            SignalEventObserver(m, LogStatus.Receive);

            switch (m.MyState)
            {
                case State.AddContact:
                    AddContact(m.Contact.Username, m.User.ContactInfo.Username);
                    break;
                case State.AddContactToChat:
                    AddContactToRoom(sessionId, m.User.ContactInfo.Username, m.ChatRoom.Id);
                    break;
                case State.Login:
                    //Must cast this to our User object so as to access the password.
                    Login(m.User.ContactInfo.Username, ((User)m.User).Password, sessionId);
                    break;
                case State.Logout:
                    Logout(m.User.ContactInfo.Username);
                    break;
                case State.OpenChat:
                    //Need to talk with Tyler. Can't remember if this is correct or not.
                    CreateRoom(m.User.ContactInfo.Username, m.Contact.Username);
                    break;
                case State.RemoveContact:
                    RemoveContact(m.Contact.Username, m.User.ContactInfo.Username);
                    break;
                case State.SendTextMessage:
                    SendTextMessage(m.ChatRoom.Id, m.TextMessage, sessionId);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            SignalObserver();
        }

        /// <summary>
        /// Puts all the users into OfflineMode, and then stores into a text file.
        /// </summary>
        /// <param name="path">The path to wehre we want to store the file.</param>
        public void StoreUsers(string path)
        {
            foreach(var u in _chatDb.Users)
            {
                u.ChangeStatus(Status.Offline);
                foreach (var contact in u.ContactList.Contacts)
                {
                    var c = (Contact) contact;
                    c.ChangeOnlineStatus(Status.Offline);
                }
            }

            using (var file = new System.IO.StreamWriter(path))
            {
                file.WriteLine(JsonConvert.SerializeObject(_chatDb));
            }
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
        internal void Register(Observer o)
        {
            _observers.Add(o);
        }

        /// <summary>
        /// Calls the list of event log observers and displays to the log the contents of a Mensaje.
        /// </summary>
        /// <param name="m">The Mensaje object.</param>
        /// <param name="s"></param>
        private void SignalEventObserver(IMensaje m, LogStatus s)
        {
            foreach(EventLogObserver o in _eventObserver)
            {
                o(m, s);
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

                SignalEventObserver(m, LogStatus.Send);
            }
            else
            {
                if (u.IsValidPassword(password))
                {
                    u.ChangeSessionId(sessionId);
                    u.ChangeStatus(Status.Online);
                    m = new Mensaje(u, false);
                    SignalEventObserver(m, LogStatus.Send);

                    foreach (var c in u.ContactList.Contacts)
                    {
                        //Change the user that is logging-in to offline for each person that has him as a contact.
                        var tempUser = _chatDb.LookupUser(c.Username);
                        ((Contact)tempUser.ContactList.GetContact(u.ContactInfo.Username)).ChangeOnlineStatus(Status.Online);

                        if (c.OnlineStatus == Status.Online)
                        {
                            _send(new Mensaje(State.Login, tempUser.ContactList), tempUser.SessionId);
                        }
                    }
                    //Implement sending to each user that is in this user's contactlist
                }
                else
                {
                    m = new Mensaje(State.Login, "The password you entered is not valid");
                    SignalEventObserver(m, LogStatus.Send);
                }
            }

            try { _send(m, sessionId); }
            catch { SignalEventObserver(new Mensaje(State.Login, "Could not login the user " + name), LogStatus.Internal); }
        }

        /// <summary>
        /// Sets a user's status to offline and notiffies each of the user's contacts that it is now offline.
        /// </summary>
        /// <param name="username">The username of the person logging out</param>
        private void Logout(string username)
        {
            var u = _chatDb.LookupUser(username);
            u.ChangeStatus(Status.Offline);
            _send(new Mensaje(State.Logout), u.SessionId);
            
            foreach(var contact in u.ContactList.Contacts)
            {
                var a = (Contact) contact;
                var t = _chatDb.LookupUser(a.Username);
                if (t == null) continue;
                
                //Change the user that is logging-in to offline for each person that has him as a contact.
                ((Contact)t.ContactList.GetContact(u.ContactInfo.Username)).ChangeOnlineStatus(Status.Online);

                var m = new Mensaje(State.Logout, t.ContactList);
                try { _send(m, t.SessionId); }
                catch { SignalEventObserver(new Mensaje(State.Logout, "Could not logout the user " + username), LogStatus.Internal); }
            }
        }

        /// <summary>
        /// Checks if the user to be added is null, if so sends an error to the Client, else puts both contacts into each other's lists.
        /// </summary>
        /// <param name="adder">The name of the user to be added.</param>
        /// <param name="toAdd">The name of the user that requested the add.</param>
        private void AddContact(string toAdd, string adder)
        {
            var a = _chatDb.LookupUser(toAdd);
            var b = _chatDb.LookupUser(adder);

            if (a == null)
            {
                var m = new Mensaje(State.AddContact, "The user " + toAdd + " does not exist");
                SignalEventObserver(m, LogStatus.Send);
                try { _send(m, b.SessionId); }
                catch { SignalEventObserver(new Mensaje(State.AddContact, "Could not send to user " + adder), LogStatus.Internal); }
            }
            else
            {
                if (!b.AddContact((Contact) a.ContactInfo))
                {
                    _send(new Mensaje(State.AddContact, "The contact " + toAdd +" already exists."), a.SessionId);
                    return;
                }
                var m = new Mensaje(State.AddContact, a.ContactInfo, b);
                SignalEventObserver(m, LogStatus.Send);

                try { _send(m, b.SessionId); }
                catch { SignalEventObserver(new Mensaje(State.AddContact, "Could not send to user " + toAdd), LogStatus.Internal); }
                a.AddContact((Contact) b.ContactInfo);

                var m2 = new Mensaje(State.AddContact, b.ContactInfo, a);
                SignalEventObserver(m2, LogStatus.Send);

                if (a.ContactInfo.OnlineStatus != Status.Online) return;

                try { _send(m2, a.SessionId); }
                catch { SignalEventObserver(new Mensaje(State.AddContact, "Could not send to user " + adder), LogStatus.Internal); }
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
                SignalEventObserver(m, LogStatus.Send);
                _send(m, a.SessionId);
            }
            else
            {
                a.RemoveContact((Contact)b.ContactInfo); 
                var m = new Mensaje(State.RemoveContact, b.ContactInfo, a);
                SignalEventObserver(m, LogStatus.Send);
                try { _send(m, a.SessionId); }
                catch { SignalEventObserver(new Mensaje(State.RemoveContact, "The user " + a.ContactInfo.Username + " is not online."), LogStatus.Internal); }

                b.RemoveContact((Contact)a.ContactInfo);
                var m2 = new Mensaje(State.AddContact, a.ContactInfo, b);
                SignalEventObserver(m2, LogStatus.Send);

                if (b.ContactInfo.OnlineStatus == Status.Online)
                {
                    try { _send(m2, b.SessionId); }
                    catch { SignalEventObserver(new Mensaje(State.RemoveContact, "Could not send to user " + b.ContactInfo.Username), LogStatus.Internal); }
                }
                else
                {
                    SignalEventObserver(new Mensaje(State.AddContact, "The user " + b.ContactInfo.Username + " is not online."), LogStatus.Internal);
                }
            }
        }

        /// <summary>
        /// Creates a chat room with two users if both users exist and are online. Notifies both users that they are
        /// now in a chat room.
        /// </summary>
        /// <param name="adder">The username of the person creating the room</param>
        /// <param name="added">The username of the person who is being added to the room.</param>
        private void CreateRoom(string adder, string added)
        {
            var a = _chatDb.LookupUser(adder);
            var b = _chatDb.LookupUser(added);

            if (b == null)
            {
                var m = (new Mensaje(State.OpenChat, "The user " + added + " does not exist"));
                _send (m, a.SessionId);
                SignalEventObserver(m, LogStatus.Send);
            }
            else if (b.ContactInfo.OnlineStatus == Status.Offline)
            {
                var m = (new Mensaje(State.OpenChat, "The user" + added + " you want to chat with is offline"));
                _send(m, a.SessionId);
                SignalEventObserver(m, LogStatus.Send);
            }
            else
            {
                var cr = _chatDb.CreateRoom(a, b);
                var cl = (ContactList) cr.ContactsToAdd;

                foreach (var c in a.ContactList.Contacts)
                {
                    if (b.ContactList.GetContact(c.Username) != null)
                    {
                        //means if cl is not null, then go ahead and do the add operation.
                        cl.Add(c as Contact);
                    }
                }

                try { _send(new Mensaje(State.OpenChat, cr), a.SessionId); }
                catch { SignalEventObserver(new Mensaje(State.OpenChat, "Error sending to client " + a.ContactInfo.Username), LogStatus.Internal ); }

                try { _send(new Mensaje(State.OpenChat, cr), b.SessionId); }
                catch { SignalEventObserver(new Mensaje(State.OpenChat, "Error sending to client " + b.ContactInfo.Username), LogStatus.Internal); }
            }
        }

        /// <summary>
        /// Sends a text message from a sender to a chat room and notifies all users in the room that a text
        /// has been sent. Checks to make sure the room exists
        /// </summary>
        /// <param name="roomId">The id of the chatroom</param>
        /// <param name="msg">The text message to be sent</param>
        /// <param name="sessionId">The sessionId of the sender</param>
        private void SendTextMessage(string roomId, ITextMessage msg, string sessionId)
        {
            var room = _chatDb.LookupRoom(roomId);

            if (room == null)
            {
                try { _send(new Mensaje(State.SendTextMessage, "This chat room no longer exists"), sessionId); }
                catch { SignalEventObserver(new Mensaje(State.AddContact, "Error sending to " + msg.Sender.Username), LogStatus.Internal); }
            }
            else
            {
                var cr = _chatDb.LookupRoom(roomId);
                cr.AddMessage((TextMessage)msg);

                foreach (var u in room.GetOnlineParticipants())
                {
                    try { _send(new Mensaje(State.SendTextMessage, room), u.SessionId); }
                    catch { SignalEventObserver(new Mensaje(State.AddContact, "The user " + u.ContactInfo.Username + " is not online."), LogStatus.Internal); }
                }
            }
        }

        /// <summary>
        /// Adds a user to a ChatRoom if the room and the user being added both exist.
        /// </summary>
        /// <param name="adderSessionId">The session id of the person adding someone to the room</param>
        /// <param name="name">The username of the person being added to the room</param>
        /// <param name="roomId">The id of the room</param>
        private void AddContactToRoom(string adderSessionId, string name, string roomId)
        {

            var user = _chatDb.LookupUser(name);

            if (user == null)
            {
                _send(new Mensaje(State.AddContactToChat, "The user you would like to add does not exist"), adderSessionId);
            }
            else if (user.ContactInfo.OnlineStatus == Status.Offline)
            {
                _send(new Mensaje(State.AddContactToChat, "The user you would like to add is not online"), adderSessionId);
            }
            else
            {
                var cr = _chatDb.LookupRoom(roomId);

                foreach (var c in cr.ContactsToAdd.Contacts)
                {
                    //Remove a contact IF the user we are adding is not friends with them
                    if (user.ContactList.GetContact(c.Username) == null)
                    {
                        cr.RemoveContact(c.Username);
                    }
                }

                _send(new Mensaje(State.OpenChat, cr), user.SessionId);
                cr.AddParticipant(user);

                foreach (var u in cr.GetOnlineParticipants())
                {
                    _send(new Mensaje(State.AddContactToChat, cr), u.SessionId);
                }
            }
        }
    }

    public class Chat : WebSocketBehavior
    {
        /// <summary>
        /// The handler that is set to refer to the controller
        /// </summary>
        private readonly ClientMessageHandler _receive;

        /// <summary>
        /// The constructor that sets _receive to the given value
        /// </summary>
        /// <param name="a">The handler being passed in</param>
        public Chat(ClientMessageHandler a)
        {
            _receive = a;
        }
        
        protected override void OnOpen()
        {

        }

        /// <summary>
        /// Receives a string from the websocket, deserializes it, and calls the 
        /// ClientMessageHandler to perform a function.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMessage(MessageEventArgs e)
        {
            if (e == null) throw new ArgumentNullException(nameof(e));

            //Deserialize this first, don't just pass a new instance...
            var m = JsonConvert.DeserializeObject<Mensaje>(e.Data);
            _receive(m, ID);
        }
        
        /// <summary>
        /// Sends an IMensaje object through the websocket to the user with the given sessionId.
        /// </summary>
        /// <param name="m">The object to be sent</param>
        /// <param name="sessionId">The id of the user to which the object is sent</param>
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
