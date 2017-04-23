using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat_CSLibrary;
using Newtonsoft.Json;

namespace Server.Model
{
    [JsonObject]
    public class User : IUser
    {
        //Stores the user's password, only can be set on initialization.
        private string _password;

        //Stores the user's session id, can be changed throughout the code.
        private string _id;

        //Stores the user's information
        private Contact _contact;

        //Stores the contacts this user has, the list canbe added to.
        private ContactList _list;

        //The public string that refers to _id
        public string SessionId => _id;

        /// <summary>
        /// Constructor for user, requires contact information and a password.
        /// </summary>
        /// <param name="i">The contact infromation</param>
        /// <param name="pass">The user's password</param>
        public User(Contact i, string pass)
        {
            _id = null;
            _contact = i;
            _list = null;
            _password = pass;
        }

        /// <summary>
        /// Changes the Id to what the parameter value
        /// </summary>
        /// <param name="toChange">the id</param>
        public void ChangeId(string toChange)
        {
            _id = toChange;
        }

        //Public IContact that refers to _contact
        [JsonProperty]
        public IContact ContactInfo => _contact;

        //Public IContactList that refers to _list
        [JsonProperty]
        public IContactList ContactList => _list;

        /// <summary>
        /// Adds a contact to the contact list
        /// </summary>
        /// <param name="name">The name of the contact to add</param>
        public void AddContact(string name)
        {
            _list.AddContact(name);
        }

        /// <summary>
        /// Changes the status of the user to represent online or offline.
        /// </summary>
        /// <param name="newState">The bool signifying whether the user is on or offline</param>
        public void ChangeStatus(Status newState)
        {
            _contact.ChangeStatus(newState);
        }

        /// <summary>
        /// Checks if the given password is valid.
        /// </summary>
        /// <param name="password">The passowrd to check</param>
        /// <returns></returns>
        public bool IsValidPassword(string password)
        {
            return _password == password;
        }
    }
}
