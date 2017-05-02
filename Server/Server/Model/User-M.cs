using System;
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
        [JsonProperty]
        private string _password;

        [JsonProperty]
        private ContactList _contactList;

        [JsonProperty]
        private Contact _contactInfo;

        public string Password => _password;

        //Maybe we need this as a JsonProperty? Do we need this SessionId if the client sends us info?
        public string SessionId { get; private set; }

        [JsonProperty]
        public IContact ContactInfo => _contactInfo;

        [JsonProperty]
        public IContactList ContactList => _contactList;

        public User(Contact contactInfoInfo, string password, string sessionId)
        {
            _contactInfo = contactInfoInfo;
            _password = password;
            SessionId = sessionId;
            _contactList = new ContactList();
        }

        [JsonConstructor]
        private User(string password, Contact contactInfoInfo, ContactList contactList)
        {
            _password = password;
            _contactInfo = contactInfoInfo;
            _contactList = contactList;
        }

        public bool IsValidPassword(string password)
        {
            return _password == password;
        }

        public void ChangeSessionId(string newId)
        {
            SessionId = newId;
        }

        public void AddContact(Contact c)
        {
            _contactList.Add(c);
        }

        public void RemoveContact(Contact c)
        {
            _contactList.Remove(c.Username);
        }

        public void ChangeStatus(Status newStatus)
        {
            _contactInfo.ChangeOnlineStatus(newStatus);
        }
    }
}
