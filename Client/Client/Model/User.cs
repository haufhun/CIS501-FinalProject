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

        //Maybe we need this as a JsonProperty? Do we need this SessionId if the client sends us info?

        //
        [JsonProperty]
        public IContact ContactInfo { get; }

        //
        [JsonProperty]
        public IContactList ContactList { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public User(string username, string password)
        {
            _password = password;
            ContactInfo = new Contact(username);
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
            ContactInfo = contactInfo;
            ContactList = contactList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsValidPassword(string password)
        {
            return _password == password;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        public void AddContact(string username)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newStatus"></param>
        public void ChangeStatus(Status newStatus)
        {
            throw new NotImplementedException();
        }
    }
}
