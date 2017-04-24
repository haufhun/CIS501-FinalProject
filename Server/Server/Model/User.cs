using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Server.Model
{
    public interface IUser
    {
        IContact ContactInfo { get; }
        IContactList ContactList { get; }
        bool IsValidPassword(string password);
    }
    [JsonObject(MemberSerialization.OptIn)]
    public class User : IUser
    {
        private string _password;

        public string SessionId { get; private set; }

        [JsonProperty]
        public IContact ContactInfo { get; }
        [JsonProperty]
        public IContactList ContactList { get; }

        public User(string password, string sessionId, ContactList list)
        {
            _password = password;
        }

        [JsonConstructor]
        public User(Contact contactInfo, ContactList contactList)
        {
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

        public void ChangeStatus(bool onlineStatus)
        {
            throw new NotImplementedException();
        }
    }
}
