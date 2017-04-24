﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using WebSocketSharp;
using WebSocketSharp.Server;
using Server.Model;
using Newtonsoft.Json;
using Chat_CSLibrary;

namespace Server.Controller
{
    //Delegate used to call the controller from the Chat WebSocketBehavior class
    public delegate void ClientMessageHandler(IMensaje m, string sessionId);
    //Delegate used to send a message back to the appropriate user
    public delegate void SendMessageHandler(IMensaje m, List<string> sessionId);

    public class ServerController
    {
        private readonly ChatDb _chatDb;

        private readonly WebSocketServer _wss;

        private SendMessageHandler _send;

        public ServerController(ChatDb db)
        {
            _chatDb = db;

            _wss = new WebSocketServer(8001);

            // Add the Chat websocket service
            _wss.AddWebSocketService("/chat", CreateChat);

            // Start the server
            _wss.Start();
        }

        ~ServerController()
        {
            //Serialize and put away the DB so it can be reloaded on startup
            _wss.Stop();
        }

        private void ChatDelegate(IMensaje m, string sessionId)
        {
            switch (m.MyState)
            {
                case State.AddContact:
                    break;
                case State.AddContactToChat:
                    break;
                case State.Login:
                    SignIn(m.User.ContactInfo.Username, "password", sessionId);
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

            throw new NotImplementedException();
        }
        private Chat CreateChat()
        {
            var c = new Chat(ChatDelegate);
            _send = c.Send;
            return c;
        }

        private void SignIn(string name, string password, string sessionId)
        {
            var u = _chatDb.LookupUser(name);

            if (u == null)
            {
                //create a new user
                _chatDb.AddUser(name, password, sessionId);
            }
            else
            {
                //validate password
                if (u.IsValidPassword(password))
                {
                    //send valid sign in
                    u.ChangeSessionId(sessionId);
                    var l = new List<string> {sessionId};

                    _send(new Mensaje(u), new List<string> {sessionId});
                }
                else
                {
                    //send error message
                }
            }
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
                //foreach (User u in room.GetAllUsers())
                //{
                //    if (u.ContactInfo.OnlineStatus == Status.Offline)
                //    {
                //        //Notify all the other users that this user is offline
                //        string sessionId = u.SessionId; //Need to add this. This is the Id associated with the user that we can use to communicate to them
                //        room.RemoveUser(u.ContactInfo.Username); //Need to implement this method as well removes a user from a chat room
                //    }
                //    else
                //    {
                //        activeIds.Add(u.SessionId);
                //    }
                //}
                //Send 
                //m = new Mensaje(room, msg);
            }

            _send(m, activeIds);
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

        public void Send(IMensaje m, List<string> sessionIds)
        {
            string message = JsonConvert.SerializeObject(m);

            foreach (string s in sessionIds)
            {
                Sessions.SendTo(s, message);
            }
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
