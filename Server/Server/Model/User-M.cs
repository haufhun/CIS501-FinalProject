﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Chat_CSLibrary;

namespace Server.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class User : IUser
    {
        /// <summary>
        /// Stores the User's password
        /// </summary>
        [JsonProperty]
        private string _password;

        /// <summary>
        /// Stores the User's contacts as a ContactList
        /// </summary>
        [JsonProperty]
        private ContactList _contactList;

        /// <summary>
        /// Keeps track of this users's contact information
        /// </summary>
        [JsonProperty]
        private Contact _contactInfo;

        public string Password => _password;

        /// <summary>
        /// Stores and gets the user's session id for connection with the server
        /// </summary>
        public string SessionId { get; private set; }

        /// <summary>
        /// Refers to the _contactInfo field and can be accessed publicly
        /// </summary>
        public IContact ContactInfo => _contactInfo;

        /// <summary>
        /// Refers to the _contactList field and can be accessed publicly
        /// </summary>
        public IContactList ContactList => _contactList;

        /// <summary>
        /// Constructor for User. Sets _contactInfo to the parameter value, sets and 
        /// stores the password and sessionId, and initializes _contactList.
        /// </summary>
        /// <param name="contactInfoInfo">The User's contact information</param>
        /// <param name="password">The password</param>
        /// <param name="sessionId">The sessionId</param>
        public User(Contact contactInfoInfo, string password, string sessionId)
        {
            _contactInfo = contactInfoInfo;
            _password = password;
            SessionId = sessionId;
            _contactList = new ContactList();
        }

        /// <summary>
        /// Constructor used only for Json
        /// </summary>
        /// <param name="password">The password</param>
        /// <param name="contactInfo">The contact information</param>
        /// <param name="contactList">The contact list</param>
        [JsonConstructor]
        private User(string password, Contact contactInfo, ContactList contactList)
        {
            _password = password;
            _contactInfo = contactInfo;
            _contactList = contactList;
        }

        /// <summary>
        /// Checks to see if the given password matches this user's password. Returns true if so,
        /// false otherwise.
        /// </summary>
        /// <param name="password">The password to be checked</param>
        /// <returns>True if they match, false if they do not</returns>
        public bool IsValidPassword(string password)
        {
            return _password == password;
        }

        /// <summary>
        /// Changes this user's session id to the given value.
        /// </summary>
        /// <param name="newId">The new session id</param>
        public void ChangeSessionId(string newId)
        {
            SessionId = newId;
        }

        /// <summary>
        /// Adds a contact to this user's contact list.
        /// </summary>
        /// <param name="c">The contact to be added</param>
        /// <returns>True if the contact was added, false otherwise</returns>
        public bool AddContact(Contact c)
        {
            return _contactList.Add(c);
        }

        /// <summary>
        /// Removes the given contact from this user's contact list.
        /// </summary>
        /// <param name="c">The contact to be removed</param>
        public void RemoveContact(Contact c)
        {
            _contactList.Remove(c.Username);
        }

        /// <summary>
        /// Changes this user's online status to the value of the parameter.
        /// </summary>
        /// <param name="newStatus">The user's new online status</param>
        public void ChangeStatus(Status newStatus)
        {
            _contactInfo.ChangeOnlineStatus(newStatus);
        }
    }
}
