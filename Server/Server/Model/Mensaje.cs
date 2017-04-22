using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_CSLibrary
{
    public class Mensaje : IMensaje
    {
        private State _statusOfMessage;

        private IUser _userObj;

        private IContact _contactObj;

        private ITextMessage _textMsgObj;

        private IChatRoom _chatRoomObj;

        private bool _isError;

        private string _errorMessage;

        public State MyState => _statusOfMessage;

        public IUser User => _userObj;

        public IContact Contact => _contactObj;

        public ITextMessage Message => _textMsgObj;

        public IChatRoom ChatRoom => _chatRoomObj;

        public bool IsError => _isError;

        public string ErrorMessage => _errorMessage;

        /// <summary>
        /// A default constructor that initializes all the contents to null.
        /// </summary>
        public Mensaje()
        {
            _userObj = null;
            _contactObj = null;
            _textMsgObj = null;
            _chatRoomObj = null;
            _isError = false;
            _errorMessage = null;
        }

        /// <summary>
        /// Constructor used to sign in/out a particular user.
        /// </summary>
        /// <param name="s">The status of the message being sent, either login or logout.</param>
        /// <param name="user">The user to be signed in.</param>
        public Mensaje(State s, IUser user)
        {
            if (s != State.Login || s != State.Logout) throw new NotSupportedException();

            _statusOfMessage = s;
            _userObj = user;
        }

        /// <summary>
        /// Constructor used to add/remove a contact to a user's contact list.
        /// </summary>
        /// <param name="s">The status of the message being sent. This should be AddContact or RemoveUser</param>
        /// <param name="c"></param>
        /// <param name="user">The user to </param>
        public Mensaje(State s, IContact c, IUser user)
        {
            if (s != State.AddContact || s != State.RemoveContact) throw new NotSupportedException();

            _statusOfMessage = s;
            _contactObj = c;
        }
        
        /// <summary>
        /// Constructor used to opne a new chat room.
        /// </summary>
        /// <param name="chatroom">The chat room that must contain the two users that desire to create a chat room.</param>
        public Mensaje(IChatRoom chatroom)
        {
            if (chatroom.NumberOfPartcipants() < 2) throw new NotSupportedException();

            _statusOfMessage = State.OpenChat;
            _chatRoomObj = chatroom;


        }
        
        /// <summary>
        /// Constructor used to send a message to a chat room.
        /// </summary>
        /// <param name="s">The status of the message being sent.</param>
        /// <param name="chatroom">The chat room object that the message should be sent to.</param>
        /// <param name="msg">The text message that is to be sent in the chat room.</param>
        public Mensaje(IChatRoom chatroom, ITextMessage msg)
        {
            _statusOfMessage = State.SendTextMessage;
            _chatRoomObj = chatroom;
            _textMsgObj = msg;
        }
        
        /// <summary>
        /// Constructor used to add a contact to a chat room.
        /// </summary>
        /// <param name="s">The status of the message being sent.</param>
        /// <param name="chatroom">The chat room ojbect to where the contact should be added.</param>
        /// <param name="c">The contact to be added to the chat room.</param>
        public Mensaje(IChatRoom chatroom, IContact c)
        {
            _statusOfMessage = State.AddContactToChat;
            _chatRoomObj = chatroom;
            _contactObj = c;
        }

        /// <summary>
        /// Constructor that creates an error message based on a error message alone.
        /// </summary>
        /// <param name="errorMessage">The message details.</param>
        public Mensaje(string errorMessage)
        {
            _isError = true;
            _errorMessage = errorMessage;
        }

        /// <summary>
        /// Constructor that creates an error message with a status and a message.
        /// </summary>
        /// <param name="s">The status that the error occurred in.</param>
        /// <param name="errorMessage">The message details.</param>
        public Mensaje(State
             s, string errorMessage)
        {
            _statusOfMessage = s;
            _isError = true;
            _errorMessage = errorMessage;
        }
    }
}
