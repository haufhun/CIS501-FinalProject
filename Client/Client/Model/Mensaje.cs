﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat_CSLibrary;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace Client.Model
{
        [JsonObject(MemberSerialization.OptIn)]
        public class Mensaje : IMensaje
        {
            //Gets and sets the state (Offline or Online)
            [JsonProperty]
            [JsonConverter(typeof(StringEnumConverter))]
            public State MyState { get; private set; }

            //Gets the user info
            [JsonProperty]
            public IUser User { get; }
            
            //Gets the chatroom info
            [JsonProperty]
            public IChatRoom ChatRoom { get; }

            //Gets the Contact info
            [JsonProperty]
            public IContact Contact { get; }

            //Gets the ContactList
            [JsonProperty]
            public IContactList ContactList { get; }

            //Gets the message
            [JsonProperty]
            public ITextMessage TextMessage { get; }

            [JsonProperty]
            //Gets error if detected
            public bool IsError { get; }

            //Gets the error message
            [JsonProperty]
            public string ErrorMessage { get; }

            //Gets information about whether the user is new
            [JsonProperty]
            public bool IsNewUser { get; }

            /// <summary>
            /// Constructor used to sign in/out a particular user.
            /// </summary>
            /// <param name="s">The status of the message being sent, either login or logout.</param>
            /// <param name="user">The user to be signed in.</param>
            public Mensaje(State s, IUser user)
            {
                if (s != State.Login && s != State.Logout) throw new NotSupportedException();

                MyState = s;
                User = user;
            }

            /// <summary>
            /// Constructor used to add/remove a contact to a user's contact list.
            /// </summary>
            /// <param name="s">The status of the message being sent. This should be AddContact or RemoveContact</param>
            /// <param name="c">The contact passed in</param>
            /// <param name="user">The user passed in </param>
            public Mensaje(State s, IContact c, IUser user)
            {
                if (s != State.AddContact && s != State.RemoveContact) throw new NotSupportedException();

                MyState = s;
                Contact = c;
                User = user;
            }

        /// <summary>
        /// Constructor used to opne a new chat room.
        /// </summary>
        /// <param name="user">User passed in</param>
        /// <param name="c">Contact passed in</param>
        public Mensaje(IUser user, IContact c)
            {
                User = user;
                Contact = c;
                MyState = State.OpenChat;
            }

        /// <summary>
        ///  This initializes Mensaje when a chatroom is passed in
        /// </summary>
        /// <param name="cRoom">The chat room that must contain the two users that desire to create a chat room.</param>
        public Mensaje(IChatRoom cRoom)
            {
                MyState = State.CloseChat;
                ChatRoom = cRoom;
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

            /// <summary>
            /// This constructor is ONLY to be used by Json in order to deserialize.
            /// </summary>
            /// <param name="user">The user to be passed. Can be null.</param>
            /// <param name="c">The contact to be passed. Can be null.</param>
            /// <param name="chatRoom">The chat room to be passed. Can be null.</param>
            /// <param name="contact"></param>
            /// <param name="s">The state to be passed.</param>
            /// <param name="contactList">The contact List to be passed.</param>
            /// <param name="textMessage">The text message to be passed.</param>
            /// <param name="isError">Whether error is true or false to be passed.</param>
            /// <param name="errorMessage">The error message to be passed.</param>
            /// <param name="isNewUser">Check result for is new user to be passed.</param>
            [JsonConstructor]
            private Mensaje(State s, User user, ChatRoom chatRoom, Contact contact, ContactList contactList,
                TextMessage textMessage, bool isError, string errorMessage, bool isNewUser)
            {
                MyState = s;
                User = user;
                ChatRoom = chatRoom;
                Contact = contact;
                ContactList = contactList;
                TextMessage = textMessage;
                IsError = isError;
                ErrorMessage = errorMessage;
                IsNewUser = isNewUser;

            }


        }
    }

