﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using Client.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebSocketSharp;
using Chat_CSLibrary;
using Client.View;


namespace Client.Controller
{
    class ClientController_C
    {
        //Observer for the Sign-In Form
        private List<SignInFormObserver> _sIFormObserver = new List<SignInFormObserver>();
        //Observer for the Home Form
        private List<HomeFormObserver> _hFormObserver = new List<HomeFormObserver>();
        //Observer for the Chat Room Form
        private List<ChatFormObserver> _cFormObserver = new List<ChatFormObserver>();
        //WebSocket private field
        private WebSocket ws;
        //private field for Model chat database
        private ChatDB _chatDB;
        // Event for when a message is received from the server
        public event Message MessageReceived;

        /// <summary>
        /// Sets up the controller for functionality of the project. 
        /// </summary>
        /// <param name="chatDb">Model chat database</param>
        public ClientController_C(ChatDB chatDb)
        {
            // Dummy ip just in cause auto-ip does not retreive an ip address.
            var webIp = "ws://192.168.0.0:8022/chat";
            var autoIP = "192.168.0.0";

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    autoIP = ip.ToString();
                    webIp = "ws://" + ip.ToString() + ":8022/chat";
                    break;
                }

            }

            ws = new WebSocket(webIp);

            ws.OnMessage += (sender, e) =>{ MessageReceived?.Invoke(e.Data); };

            ws.Connect();
            if (!ws.IsAlive)
            {
                var setIPForm = new AddContactForm
                {
                    Text = "Set IP",
                    label1 = {Text = "Could not auto connect. Please input\rthe IP address of the server."},
                    uxAdd = {Text = "Connect"},
                    uxCancel = {Text = "Exit"},
                    uxTxt = {Text = autoIP }
                };

                setIPForm.ShowDialog();

                switch (setIPForm.DialogResult)
                {
                    case DialogResult.OK:
                        ws = new WebSocket("ws://" + setIPForm.uxTxt.Text + ":8022/chat");
                        ws.OnMessage += (sender, e) => { MessageReceived?.Invoke(e.Data); };
                        ws.Connect();
                        if (!ws.IsAlive) { throw new Exception("Cant connect to server! Exiting program..."); }

                        break;
                    case DialogResult.Cancel:
                                setIPForm.Close();
                                throw new Exception("Exiting program...");
                        break;
                }

                
           
            }
            _chatDB = chatDb;


        }

        /// <summary>
        /// Makes sure to close the websocket when the controller is destructed
        /// </summary>
        ~ClientController_C()
        {
            ws.Close();
        }

        /// <summary>
        /// This method keeps track of the state the message is in and acts appropriately for each state
        /// </summary>
        /// <param name="e">Message passed in</param>
        /// <returns>Boolean returned</returns>
        public bool message(string e)
        {
            if (e == null) throw new ArgumentNullException(nameof(e));

            var m = JsonConvert.DeserializeObject<Mensaje>(e);

            switch (m.MyState)
            {
                case State.Login:
                    //If m.ContactList is null (this) is signing in.
                    //If it isnt null update (this) contact list.
                    if (!m.IsError)
                    {
                        if (Equals(m.ContactList, null))
                        {
                            _chatDB.User = (User)m.User;
                            SignalSIFormObsever(0);
                            SignalHFormObserver(0);
                        }
                        else
                        {
                            _chatDB.User.UpdateContactList((ContactList)m.ContactList);
                            SignalHFormObserver(0);
                        }
                    }
                    else
                        SignalSIFormObsever(1);

                    break;

                case State.Logout:
                    //If m.contact list is null (this) is signing out 
                    //If it isnt null update (this) contact list.
                    if (!m.IsError)
                    {
                        if (Equals(m.ContactList, null))
                        {
                            SignalHFormObserver(1);
                            SignalSIFormObsever(2);
                        }
                        else
                        {
                            _chatDB.User.UpdateContactList((ContactList)m.ContactList);
                            SignalHFormObserver(0);
                        }

                    }
                    else MessageBox.Show(m.ErrorMessage);
                    break;

                case State.AddContact:        
                    // Removes the contact from friends list
                    if (!m.IsError)
                    {
                        _chatDB.User = (User) m.User;
                        SignalHFormObserver(0);
                    }
                    else MessageBox.Show(m.ErrorMessage);
                    break;

                case State.RemoveContact:
                    // Removes the contact from friends list
                    if (!m.IsError)
                    {
                        _chatDB.User = (User)m.User;
                        SignalHFormObserver(0);
                    }
                    else MessageBox.Show(m.ErrorMessage);                  
                    break;

                case State.OpenChat:
                    // Takes care of opening a chatroom with two users.
                    // State OpenChat when adding to chat room- this will be for the person getting added. It will contain IChat and has list of messages and contacts.
                    if (!m.IsError)
                    {
                        if (!_chatDB.ChatRooms.ContainsKey(m.ChatRoom.Id))
                            _chatDB.ChatRooms.Add(m.ChatRoom.Id, (ChatRoom) m.ChatRoom);

                        else _chatDB.ChatRooms[m.ChatRoom.Id] = (ChatRoom) m.ChatRoom;

                        SignalCFormObserver(0, (ChatRoom)m.ChatRoom, null);
                        
                    }
                    else MessageBox.Show(m.ErrorMessage);
                    break;
                case State.CloseChat:
                    // Closes the chatroom
                    if (!m.IsError)
                    {
                        MessageBox.Show("Closing because someone ended the chat.");

                        var cForm = _chatDB.ChatForms[m.ChatRoom.Id];
                        cForm.Invoke(new MethodInvoker(cForm.Close));

                        _chatDB.ChatForms.Remove(m.ChatRoom.Id);
                        _chatDB.ChatRooms.Remove(m.ChatRoom.Id);
                    }
                    else MessageBox.Show(m.ErrorMessage);
                    break;
                case State.AddContactToChat:
                    // State OpenChat- this will be for the person getting added to chat room. It will contain IChat and has list of messages and contacts.
                    // State AddContactToChat when adding to chat room - this will be for current users in chatroom it will contain IChat with updated contact list to update the views
                    if (!m.IsError)
                    {
                        _chatDB.ChatRooms[m.ChatRoom.Id] = (ChatRoom) m.ChatRoom;
                        SignalCFormObserver(1, (ChatRoom) m.ChatRoom, _chatDB.ChatForms[m.ChatRoom.Id]);
                    }
                    else MessageBox.Show(m.ErrorMessage);
                    break;

                case State.SendTextMessage:
                    // Get most recent text message object and updates chatforms.
                    if (!m.IsError)
                    {
                        _chatDB.ChatRooms[m.ChatRoom.Id] = (ChatRoom) m.ChatRoom;
                        SignalCFormObserver(1, (ChatRoom) m.ChatRoom, _chatDB.ChatForms[m.ChatRoom.Id]);
                    }
                    else MessageBox.Show(m.ErrorMessage);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            return true;
        }

        /// <summary>
        /// Register for the sign in with the controller
        /// </summary>
        /// <param name="o">The Observer for sign in form passed in</param>
        public void SignInRegister(SignInFormObserver o)
        {
            _sIFormObserver.Add(o);
        }

        /// <summary>
        /// Register for the homeform in the controller
        /// </summary>
        /// <param name="o">The Observer for the home form passed in</param>
        public void HomeFormRegister(HomeFormObserver o)
        {
            _hFormObserver.Add(o);
        }

        /// <summary>
        /// Register for the chat form in the controller
        /// </summary>
        /// <param name="o">The Observer for the chat form passed in</param>
        public void ChatFormRegister(ChatFormObserver o)
        {
            _cFormObserver.Add(o);
        }

        /// <summary>
        /// A method that creates a new sign in mensaje and sends it to server.
        /// </summary>
        /// <param name="name">Username of account</param>
        /// <param name="password">Password of account</param>
        public void SignIn(string name, string password)
        {
            if (ws.IsAlive)
            {
                var m = new Mensaje(State.Login, new User(name, password));
                var output = JsonConvert.SerializeObject(m);

                ws.Send(output);
            }
            else
            {
                MessageBox.Show("Cant connect to server. Trying to reconnect..");
                ws.Connect();
                MessageBox.Show(ws.IsAlive
                    ? "Reconnection was successful! Please try to sign in again."
                    : "Reconnection was unsuccessful... Try checking the servers IP adress and making sure you are on the same network.");
            }
        }
        /// <summary>
        /// A method that creates a new sign out mensaje and sends it to server.
        /// </summary>
        public void SignOut()
        {
            if (ws.IsAlive)
            {
                var m = new Mensaje(State.Logout, _chatDB.User);
                var output = JsonConvert.SerializeObject(m);

                ws.Send(output);
            }
            else
            {
                MessageBox.Show("Cant connect to server. Trying to reconnect..");
                ws.Connect();
                if (ws.IsAlive)
                {
                    MessageBox.Show("Reconnection was successful! Please try to sign out again.");
                }
                else
                {
                    MessageBox.Show("Reconnection was unsuccessful, but will sign out anyway...");
                    SignalHFormObserver(1);
                    SignalSIFormObsever(2);
                }
            }

        }

        /// <summary>
        /// A method that creates a new add contact mensaje and sends it to server
        /// </summary>
        /// <param name="name">Contact name passed in</param>
        public void AddContact(string name)
        {
            if (ws.IsAlive)
            {
                var m = new Mensaje(State.AddContact, new Contact(name), _chatDB.User);
                var output = JsonConvert.SerializeObject(m);

                ws.Send(output);
            }
            else
            {
                MessageBox.Show("Cant connect to server!");
            }
        }

        /// <summary>
        /// A method that creates a new remove contact mensaje and sends it to server
        /// </summary>
        /// <param name="name">Contact name passed in</param>
        public void RemoveContact(string name)
        {
            if (ws.IsAlive)
            {
                var m = new Mensaje(State.RemoveContact, new Contact(name), _chatDB.User); // maybe get contact from contact list dictionary in  a Database class??
                var output = JsonConvert.SerializeObject(m);

                ws.Send(output);
            }
            else
            {
                MessageBox.Show("Cant connect to server!");
            }
        }

        /// <summary>
        /// A method that creates a chat room mensaje and sends it to server
        /// </summary>
        /// <param name="name">Contact name passed in</param>
        public void CreateChatRoom(string name)
        {
            if (ws.IsAlive)
            {
                var m = new Mensaje(_chatDB.User, _chatDB.User.ContactList.GetContact(name)); 
                var output = JsonConvert.SerializeObject(m);

                ws.Send(output);
            }
            else
            {
                MessageBox.Show("Cant connect to server!");
            }
        }
        /// <summary>
        /// A method that creates a close chat room mensaje and sends it to server
        /// </summary>
        /// <param name="cRoom">Chatroom object passed in</param>
        public void CloseChatRoom(ChatRoom cRoom)
        {
            if (ws.IsAlive)
            {
                var m = new Mensaje(cRoom);
                var output = JsonConvert.SerializeObject(m);

                ws.Send(output);
            }
            else
            {
                MessageBox.Show("Cant connect to server!");
            }
        }
        /// <summary>
        /// This method creates a mensaje for adding a contact to the chat room and sends it to server
        /// </summary>
        /// <param name="chatRoom">Chatroom passed in</param>
        /// <param name="name">Name of the contact passed in</param>
        public void AddContactToRoom(ChatRoom chatRoom, string name)
        {
            if (ws.IsAlive)
            {
                var m = new Mensaje(chatRoom, _chatDB.User.ContactList.GetContact(name));
                var output = JsonConvert.SerializeObject(m);

                ws.Send(output);
            }
            else
            {
                MessageBox.Show("Cant connect to server!");
            }
        }

        /// <summary>
        /// A method to create a mensaje for sending a message and sends it the server
        /// </summary>
        /// <param name="message">Message to be sent passed in</param>
        /// <param name="chatRoom">Chatroom passed in</param>
        /// <param name="cForm">This is Chatform passed in</param>
        public void SendMessage(string message, ChatRoom chatRoom, ChatForm cForm)
        {
            if (ws.IsAlive)
            {
                var m = new Mensaje(chatRoom, new TextMessage(message, _chatDB.User.ContactInfo)); 
                var output = JsonConvert.SerializeObject(m);

                ws.Send(output);
            }
            else
            {
                MessageBox.Show("Cant connect to server!");
            }
        }

        /// <summary>
        /// This method signals the CForm Observer
        /// </summary>
        /// <param name="index">
        ///  Calls the StartChat method from homeform if index of [0]
        ///  Calls the SendTextmessage method from homeForm if index of [1]
        /// </param>
        /// <param name="chatRoom"> Current chatroom that is needed. </param>
        private void SignalCFormObserver(int index, ChatRoom chatRoom, ChatForm cForm)
        {
            
            _cFormObserver[index](chatRoom, cForm);
        }

        /// <summary>
        /// A method to signal the home form Observer
        /// </summary>
        /// <param name="index">
        ///  Calls Update if index of [0]
        ///  Calls SignOut if Index of [1]
        ///  Calls AddContact if index is [2]
        ///  Calls RemoveContact if index is [3]
        /// </param>
        private void SignalHFormObserver(int index)
        {

            _hFormObserver[index]();
        }

        /// <summary>
        /// A method to signal the Sign in Form Observer
        /// </summary>
        /// <param name="index"> 
        ///  Calls EventSuccessfulLogin if index of [0]
        ///  Calls EventUnsuccessfulLogin if Index of [1]
        ///  Calls SignOut if Index of [2]
        /// </param>
        private void SignalSIFormObsever(int index)
        {
            
            _sIFormObserver[index]();
           

        }

     
    }

}
