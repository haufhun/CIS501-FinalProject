﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Client.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebSocketSharp;
using Chat_CSLibrary;


namespace Client.Controller
{
    class ClientController_C
    {
        private List<SignInFormObserver> _sIFormObserver = new List<SignInFormObserver>();

        private List<HomeFormObserver> _hFormObserver = new List<HomeFormObserver>();

        private List<ChatFormObserver> _cFormObserver = new List<ChatFormObserver>();

        private WebSocket ws;

        private IUser _user;
        

        // Event for when a message is received from the server
        public event Message MessageReceived;

        public ClientController_C()
        {
            // Connects to the server
            ws = new WebSocket("ws://192.168.0.12:8022/chat");
            ws.OnMessage += (sender, e) => { if (MessageReceived != null) MessageReceived(e.Data); };

            ws.Connect();
        }

        // Makes sure to close the websocket when the controller is destructed
        ~ClientController_C()
        {
            ws.Close();
        }

        public bool message(string e)
        {
            if (e == null) throw new ArgumentNullException(nameof(e));
            //Deserialize this first, don't just pass a new instance...
            var m = JsonConvert.DeserializeObject<Mensaje>(e);
            switch (m.MyState)
            {
                case State.AddContact:
                    break;

                case State.RemoveContact:
                    break;

                case State.AddContactToChat:
                    break;

                case State.Login:
                    SignalSIFormObsever(m.IsError ? 1 : 0);
                    if (m.IsError) MessageBox.Show(m.ErrorMessage);
                    _user = m.User;
                    break;

                case State.Logout:
                    SignalHFormObserver(1);
                    SignalSIFormObsever(2);                  
                    break;

                case State.OpenChat:
                    SignalCFormObserver(0, m.ChatRoom);
                    break;

                case State.SendTextMessage:
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            return true;
        }


        public void SignInRegister(SignInFormObserver o)
        {
            _sIFormObserver.Add(o);
        }

        public void HomeFormRegister(HomeFormObserver o)
        {
            _hFormObserver.Add(o);
        }

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
                string output = JsonConvert.SerializeObject(m);

                ws.Send(output);
            }
            else
            {
                MessageBox.Show("Cant connect to server!");
            }
        }
        /// <summary>
        /// A method that creates a new sign out mensaje and sends it to server.
        /// </summary>
        public void SignOut()
        {
            if (ws.IsAlive)
            {
                var m = new Mensaje(State.Logout, _user);
                string output = JsonConvert.SerializeObject(m);

                ws.Send(output);
            }
            else
            {
                MessageBox.Show("Cant connect to server!");
            }

        }

        public void AddContact(string name)
        {
            if (ws.IsAlive)
            {
                var m = new Mensaje(State.AddContact, new Contact(name), _user);
                string output = JsonConvert.SerializeObject(m);

                ws.Send(output);
            }
            else
            {
                MessageBox.Show("Cant connect to server!");
            }
        }

        public void RemoveContact(string name)
        {
            if (ws.IsAlive)
            {
                var m = new Mensaje(State.RemoveContact, new Contact(name), _user); // maybe get contact from contact list dictionary in  a Database class??
                string output = JsonConvert.SerializeObject(m);

                ws.Send(output);
            }
            else
            {
                MessageBox.Show("Cant connect to server!");
            }
        }

        public void AddContactToRoom(IChatRoom chatRoom, string name)
        {
            if (ws.IsAlive)
            {
                var m = new Mensaje(chatRoom, new Contact(name)); // maybe get contact from contact list dictionary in  a Database class??
                string output = JsonConvert.SerializeObject(m);

                ws.Send(output);
            }
            else
            {
                MessageBox.Show("Cant connect to server!");
            }
        }

        public void CreateChatRoom()
        {
            if (ws.IsAlive)
            {
                var m = new Mensaje(new ChatRoom(null));
                string output = JsonConvert.SerializeObject(m);

                ws.Send(output);
            }
            else
            {
                MessageBox.Show("Cant connect to server!");
            }
        }


        private void SignalCFormObserver(int index, IChatRoom chatRoom)
        {
            _cFormObserver[index](chatRoom);
        }
        private void SignalHFormObserver(int index)
        {
            //calls Update if index of [0]
            //Calls SignOut if Index of [1]
            _hFormObserver[index]();
        }

        private void SignalSIFormObsever(int index)
        {
            //calls EventSuccessfulLogin if index of [0]
            //Calls EventUnsuccessfulLogin if Index of [1]
            //Calls SignOut if Index of [2]
            _sIFormObserver[index]();
           

        }

     
    }

}
