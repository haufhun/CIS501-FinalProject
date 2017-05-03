using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Chat_CSLibrary;

namespace Client.Model
{
    /// <summary>
    /// This class holds the User information in the Model
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class User : IUser
    {
        /// <summary>
        /// Private field storing the password
        /// </summary>
        [JsonProperty]
        private string _password;

        /// <summary>
        /// Private field for a Contact object storing the contact list
        /// </summary>
        [JsonProperty]
        private ContactList _contactList;
      
        /// <summary>
        /// Private field for a Contact object storing the contact info
        /// </summary>
        [JsonProperty]
        private Contact _contactInfo;
       
        /// <summary>
        /// Public getter from ContactInfo to a private field
        /// </summary>
        public IContact ContactInfo => _contactInfo;
        
        /// <summary>
        /// Public getter from ContactList to a private field
        /// </summary>
        public IContactList ContactList => _contactList;

        /// <summary>
        /// This is the constructor for User, initializes the username and password
        /// </summary>
        /// <param name="username">Username being passed in</param>
        /// <param name="password">Password being passed in</param>
        public User(string username, string password)
        {
            _password = password;
            _contactInfo = new Contact(username);
        }

        /// <summary>
        /// This method updates info for JSON
        /// </summary>
        /// <param name="password">Password being passed in</param>
        /// <param name="contactInfo">Contact info being passed in</param>
        /// <param name="contactList">Contact list being passed in</param>
        [JsonConstructor]
        private User(string password, Contact contactInfo, ContactList contactList)
        {
            _password = password;
            _contactInfo = contactInfo;
            _contactList = contactList;
        }
        /// <summary>
        /// This method updates the Contact List in the Model
        /// </summary>
        /// <param name="cl">The contactList object being passed in</param>
        public void UpdateContactList(ContactList cl)
        {
            _contactList = cl;
        }
    }
}
