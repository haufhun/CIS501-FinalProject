using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Chat_CSLibrary;
using Newtonsoft.Json.Converters;
using System.Data;
using System.Globalization;

namespace Server.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Mensaje : IMensaje
    {
        /// <summary>
        /// The state of this Mensaje, which is used to determine which course of action to take.
        /// </summary>
        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        public State MyState { get; private set; }

        //Each of the following properties can be used differently based on the State

        /// <summary>
        /// The User
        /// </summary>
        [JsonProperty]
        public IUser User { get; }

        /// <summary>
        /// The ChatRoom
        /// </summary>
        [JsonProperty]
        public IChatRoom ChatRoom { get; }

        /// <summary>
        /// The Contact
        /// </summary>
        [JsonProperty]
        public IContact Contact { get; }

        /// <summary>
        /// The ContactList
        /// </summary>
        [JsonProperty]
        public IContactList ContactList { get; }

        /// <summary>
        /// The TextMessage (only used when a message is sent)
        /// </summary>
        [JsonProperty]
        public ITextMessage TextMessage { get;  }

        /// <summary>
        /// Indicates that an error occurred
        /// </summary>
        [JsonProperty]
        public bool IsError { get; }

        /// <summary>
        /// The message associated with the error
        /// </summary>
        [JsonProperty]
        public string ErrorMessage { get; }

        /// <summary>
        /// Indicates whether the user is new
        /// </summary>
        [JsonProperty]
        public bool IsNewUser { get; }

        /// <summary>
        /// Used to make the Mensaje readable
        /// </summary>
        public IEnumerable<string> ArrayString => new[]
        {
            DateTime.Now.ToString(CultureInfo.CurrentCulture),
            !Equals(User, null) ? User.ContactInfo.Username : "null",
            !Equals(User, null) ? ((User)User).SessionId : "null",
            MyState.ToString(),
            IsNewUser.ToString(),
            IsError.ToString(),
            !Equals(ErrorMessage, null) ? ErrorMessage.ToString() : "",
            !Equals(ChatRoom, null) ? ChatRoom.Id : "",
        };


        /// <summary>
        /// Login
        /// </summary>
        /// <param name="user">The user to be signed in.</param>
        /// <param name="isNewUser">If the user was a new user or not.</param>
        public Mensaje(IUser user, bool isNewUser)
        {
            MyState = State.Login;
            User = user;
            IsNewUser = isNewUser;
        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <param name="s">The state, should be set to Logout</param>
        public Mensaje(State s)
        {
            MyState = s;
        }

        /// <summary>
        /// Login/Logout to other contacts
        /// </summary>
        /// <param name="s">The state of this message</param>
        /// <param name="cl">The list of contacts</param>
        public Mensaje(State s, IContactList cl)
            {
                MyState = s;
                ContactList = cl;
            }

        /// <summary>
        /// Add/Remove Contact
        /// </summary>
        /// <param name="s">The status of the message being sent. This should be AddContact or RemoveContact</param>
        /// <param name="c">The contact to be added/removed</param>
        /// <param name="user">The user that adds/removes</param>
        public Mensaje(State s, IContact c, IUser user)
        {
            if (s != State.AddContact && s != State.RemoveContact) throw new NotSupportedException();

            MyState = s;
            Contact = c;
            User = user;
        }

        /// <summary>
        /// Open Chat/Send Message/Add Contact to chat. Send an OpenChat to a User that has been added to an existing ChatRoom.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="chatroom"></param>
        public Mensaje(State s, IChatRoom chatroom)
        {
            if (s != State.AddContactToChat && s != State.OpenChat && s != State.SendTextMessage && s != State.CloseChat) throw new InvalidConstraintException();

            MyState = s;
            ChatRoom = chatroom;
        }


        /// <summary>
        /// Constructor that creates an error message based on an error message alone.
        /// </summary>
        /// <param name="errorMessage">The message details.</param>
        public Mensaje(string errorMessage)
        {
            IsError = true;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Constructor that creates an error message with a status and a message.
        /// </summary>
        /// <param name="s">The status that the error occurred in.</param>
        /// <param name="errorMessage">The message details.</param>
        public Mensaje(State s, string errorMessage)
        {
            MyState = s;
            IsError = true;
            ErrorMessage = errorMessage;
        }


        /// <summary>
        /// This constructor is ONLY to be used by Json in order to deserialize.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="user">The user to be passed. Can be null.</param>
        /// <param name="c">The contact to be passed. Can be null.</param>
        /// <param name="chatRoom">The chat room to be passed. Can be null.</param>
        /// <param name="contact"></param>
        /// <param name="contactList"></param>
        /// <param name="textMessage"></param>
        /// <param name="isError"></param>
        /// <param name="errorMessage"></param>
        [JsonConstructor]
        private Mensaje(State s, User user, ChatRoom chatRoom, Contact contact, ContactList contactList, TextMessage textMessage, bool isError, string errorMessage)
        {
            MyState = s;
            User = user;
            ChatRoom = chatRoom;
            Contact = contact;
            ContactList = contactList;
            TextMessage = textMessage;
        }

//////////////////////// Client constructors. Only for testing.

        /// <summary>
        /// Login/Logout sent by server
        /// </summary>
        /// <param name="s"></param>
        /// <param name="u"></param>
        public Mensaje(State s, IUser u)
        {
            MyState = s;
            User = u;
        }
        
        /// <summary>
        /// Constructor used to open a new chat room.
        /// </summary>
        /// <param name="chatroom">The chat room that must contain the two users that desire to create a chat room.</param>
        /// <param name="u">The user that is requesting the chat room to be opened.</param>
        public Mensaje(IChatRoom chatroom, User u)
        {
            if (chatroom.Participants.Count() < 2) throw new NotSupportedException();

            MyState = State.OpenChat;
            ChatRoom = chatroom;
            User = u;
        }

        /// <summary>
        /// Constructor used to send a message to a chat room.
        /// </summary>
        /// <param name="chatroom">The chat room object that the message should be sent to.</param>
        /// <param name="msg">The text message that is to be sent in the chat room.</param>
        public Mensaje(IChatRoom chatroom, ITextMessage msg)
        {
            MyState = State.SendTextMessage;
            ChatRoom = chatroom;
            TextMessage = msg;
        }

        /// <summary>
        /// Constructor used to add a contact to a chat room. This is what the client should use.
        /// </summary>
        /// <param name="chatroom">The chat room ojbect to where the contact should be added.</param>
        /// <param name="c">The contact to be added to the chat room.</param>
        public Mensaje(IChatRoom chatroom, IContact c)
        {
            MyState = State.AddContactToChat;
            ChatRoom = chatroom;
            Contact = c;
        }
    }
}
