using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Client.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebSocketSharp;
using Chat_CSLibrary;
//using System.Net.WebSockets;

namespace Client.Controller
{
    class ClientController_C
    {
        private List<SignInFormObserver> _sIFormObserver = new List<SignInFormObserver>();

        private List<HomeFormObserver> _hFormObserver = new List<HomeFormObserver>();

        private List<ChatFormObserver> _cFormObserver = new List<ChatFormObserver>();

        private string name;

        private WebSocket ws;

        // Event for when a message is received from the server
        public event Message MessageReceived;

        public ClientController_C(string name)
        {
            this.name = name;

            // Connects to the server
            ws = new WebSocket("ws://192.168.2.4:8022/chat");
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
                case State.AddContactToChat:
                    break;
                case State.Login:
                    if (m.IsError)
                    {
                        
                    }
                    else
                    {
                        SignalSIFormObsever(true);
                    }
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
                MessageBox.Show("Hunters server sucks I cant connect");
            }
        }

        public void AddContact(string name)
        {
            
        }

        public void RemoveContact(string name)
        {
            
        }

        public void AddContactToRoom(string name)
        {
            
        }

        public void CreateRoom()
        {
            
        }
        private void SignalCFormObserver()
        {

        }
        private void SignalHFormObserver()
        {
            
        }

        private void SignalSIFormObsever(bool successful)
        {
            //calls EventSuccessfulLogin if true index of [0]
            if (successful)
            {
                SignInFormObserver s = _sIFormObserver[0];
                s();
            }
            //calls EventUnsuccessfulLogin if false index of [1]
            else
            {
                _sIFormObserver[1]();
            }
        }

     
    }

}
