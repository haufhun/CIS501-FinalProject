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

        private string name;
        private WebSocket ws;

        // Event for when a message is received from the server
        public event Message MessageReceived;

        public ClientController_C(string name)
        {
            this.name = name;

            // Connects to the server
            ws = new WebSocket("ws://192.168.2.4:8001/chat");
            ws.OnMessage += (sender, e) => { if (MessageReceived != null) MessageReceived(e.Data); };
            ws.Connect();
        }

        // Handles when a new message is entered by the user
        public bool MessageEntered(string message)
        {
            // Send the message to the server if connection is alive
            if (ws.IsAlive)
            {
                ws.Send(name + ": " + message);
                return true;
            }
            else
            {
                return false;
            }
        }

        // Makes sure to close the websocket when the controller is destructed
        ~ClientController_C()
        {
            ws.Close();
        }
        private SignInFormObserver _sIFormObserver;

        private List<HomeFormObserver> _hFormObserver = new List<HomeFormObserver>();

        private List<ChatFormObserver> _cFormObserver = new List<ChatFormObserver>();

        public void SignInRegister(SignInFormObserver o)
        {
            _sIFormObserver = o;
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

        private void SignalSIFormObsever()
        {
            
        }

        
    }

}
