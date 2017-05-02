using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Chat_CSLibrary;

namespace Client.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class User : IUser
    {
        [JsonProperty]
        private string _password;

        [JsonProperty]
        private ContactList _contactList;

        [JsonProperty]
        private Contact _contactInfo;

        public IContact ContactInfo => _contactInfo;

        public IContactList ContactList => _contactList;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public User(string username, string password)
        {
            _password = password;
            _contactInfo = new Contact(username);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="contactInfo"></param>
        /// <param name="contactList"></param>
        [JsonConstructor]
        private User(string password, Contact contactInfo, ContactList contactList)
        {
            _password = password;
            _contactInfo = contactInfo;
            _contactList = contactList;
        }

        public void UpdateContactList(ContactList cl)
        {
            _contactList = cl;
        }
    }
}
