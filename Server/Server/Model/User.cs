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
        public string Password => _password;

        //Maybe we need this as a JsonProperty? Do we need this SessionId if the client sends us info?
        public string SessionId { get; private set; }

        [JsonProperty]
        public IContact ContactInfo { get; }
        [JsonProperty]
        public IContactList ContactList { get; }

        public User(Contact contactInfo, string password, string sessionId)
        {
            ContactInfo = contactInfo;
            _password = password;
            SessionId = sessionId;
        }

        [JsonConstructor]
        private User(string password, Contact contactInfo, ContactList contactList)
        {
            _password = password;
            ContactInfo = contactInfo;
            ContactList = contactList;
        }

        public bool IsValidPassword(string password)
        {
            return _password == password;
        }

        public void ChangeSessionId(string newId)
        {
            SessionId = newId;
        }

        public void AddContact(string username)
        {
            throw new NotImplementedException();
        }

        public void ChangeStatus(Status newStatus)
        {
            throw new NotImplementedException();
        }
    }
}
