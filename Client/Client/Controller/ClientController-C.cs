using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
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
        /// Constructor for Controller
        /// </summary>
        /// <param name="chatDb">Model chat database</param>
        public ClientController_C(ChatDB chatDb)
        {
            string webIp = "ws://192.168.0.0:8022/chat";

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                   webIp = "ws://" + ip.ToString() +":8022/chat";
                    break;
                }
                
            }
           ws = new WebSocket("ws://192.168.2.4:8022/chat");
           //ws = new WebSocket(webIp);

            ws.OnMessage += (sender, e) => { if (MessageReceived != null) MessageReceived(e.Data); };

            ws.Connect();
            if (!ws.IsAlive)
            {
                throw new Exception("Cant connect to server!");
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
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
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
                    //If m.user is null (this) is signing out 
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
                    else
                        MessageBox.Show(m.ErrorMessage);
                    break;

                case State.AddContact:        
                    if (!m.IsError)
                    {
                        _chatDB.User = (User) m.User;
                        SignalHFormObserver(0);
                    }
                    else
                        MessageBox.Show(m.ErrorMessage);

                    break;

                case State.RemoveContact:
                    if (!m.IsError)
                    {
                        _chatDB.User = (User)m.User;
                        SignalHFormObserver(0);
                    }
                    else
                        MessageBox.Show(m.ErrorMessage);
                    
                    break;

                case State.OpenChat:
                    if (!m.IsError)
                    {
                        _chatDB.ChatRooms.Add(m.ChatRoom.Id, (ChatRoom)m.ChatRoom);
                        
                        SignalCFormObserver(0, (ChatRoom)m.ChatRoom, null);
                        
                    }
                    else
                        MessageBox.Show(m.ErrorMessage);

                    break;

                case State.AddContactToChat:
                    // state open chat- this will be for the person getting added. it will contain IChat and has list of messages and contacts
                    //state is addcontactochat - ths is for current users in chatroom it iwll contain IChat will have the upadted contact list to update the views
                    _chatDB.ChatRooms[m.ChatRoom.Id] = (ChatRoom)m.ChatRoom;
                    SignalCFormObserver(1, (ChatRoom) m.ChatRoom, _chatDB.CurrentChatForm[m.ChatRoom.Id]);

                    break;

                case State.SendTextMessage:
                    _chatDB.ChatRooms[m.ChatRoom.Id] = (ChatRoom) m.ChatRoom;
                    SignalCFormObserver(1, (ChatRoom) m.ChatRoom,_chatDB.CurrentChatForm[m.ChatRoom.Id]);
                    // a Chatroom // get most recent text message object and populates it.
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        public void SignInRegister(SignInFormObserver o)
        {
            _sIFormObserver.Add(o);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        public void HomeFormRegister(HomeFormObserver o)
        {
            _hFormObserver.Add(o);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
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
                var m = new Mensaje(State.Logout, _chatDB.User);
                var output = JsonConvert.SerializeObject(m);

                ws.Send(output);
            }
            else
            {
                MessageBox.Show("Cant connect to server!");
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
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
        /// 
        /// </summary>
        /// <param name="name"></param>
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
        /// 
        /// </summary>
        /// <param name="name"></param>
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
        /// 
        /// </summary>
        /// <param name="chatRoom"></param>
        /// <param name="name"></param>
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
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="chatRoom"></param>
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
        /// 
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
        /// 
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
        /// 
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
