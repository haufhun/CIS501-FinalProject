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

        [JsonProperty]
        public IContact ContactInfo { get; }
        [JsonProperty]
        public IContactList ContactList { get; }

        public User(string username, string password)
        {
            _password = password;
            ContactInfo = new Contact(username);
        }

        [JsonConstructor]
        private User(Contact contactInfo, ContactList contactList)
        {
            ContactInfo = contactInfo;
            ContactList = contactList;
        }

        public bool IsValidPassword(string password)
        {
            return _password == password;
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
