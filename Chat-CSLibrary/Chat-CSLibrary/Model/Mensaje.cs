using System;
using Chat_CSLibrary;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Server.Model
{
    [JsonObject]
    public class Mensaje : IMensaje
    {
        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        public State MyState { get; private set; }
        [JsonProperty]
        public IUser User { get; private set; }
        [JsonProperty]
        public IContact Contact { get; private set; }
        [JsonProperty]
        public ITextMessage Message { get; private set; }
        [JsonProperty]
        public IChatRoom ChatRoom { get; private set; }
        [JsonProperty]
        public bool IsError { get; private set; }
        [JsonProperty]
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// A default constructor that initializes all the contents to null.
        /// </summary>
        public Mensaje()
        {
            User = null;
            Contact = null;
            Message = null;
            ChatRoom = null;
            IsError = false;
            ErrorMessage = null;
        }
        [JsonConstructor]
        public Mensaje(State s, User u, Contact c, TextMessage m, ChatRoom r)
        {
            MyState = s;
            User = u;
            Contact = c;
            Message = m;
            ChatRoom = r;
        }

        /// <summary>
        /// Constructor used to sign in/out a particular user.
        /// </summary>
        /// <param name="s">The status of the message being sent, either login or logout.</param>
        /// <param name="user">The user to be signed in.</param>
        public Mensaje(State s, IUser user)
        {
            if (s != State.Login || s != State.Logout) throw new NotSupportedException();

            MyState = s;
            User = user;
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

            MyState = s;
            Contact = c;
        }

        /// <summary>
        /// Constructor used to opne a new chat room.
        /// </summary>
        /// <param name="chatroom">The chat room that must contain the two users that desire to create a chat room.</param>
        public Mensaje(ChatRoom chatroom)
        {
            //if (chatroom.NumberOfPartcipants() < 2) throw new NotSupportedException();

            MyState = State.OpenChat;
            ChatRoom = chatroom;
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
            Message = msg;
        }

        /// <summary>
        /// Constructor used to add a contact to a chat room.
        /// </summary>
        /// <param name="chatroom">The chat room ojbect to where the contact should be added.</param>
        /// <param name="c">The contact to be added to the chat room.</param>
        public Mensaje(IChatRoom chatroom, IContact c)
        {
            MyState = State.AddContactToChat;
            ChatRoom = chatroom;
            Contact = c;
        }

        /// <summary>
        /// Constructor that creates an error message based on a error message alone.
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
    }
}
