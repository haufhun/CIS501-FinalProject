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
    public class ContactList : IContactList
    {
        [JsonProperty]
        private Dictionary<string, IContact> _contacts;

        [JsonConstructor]
        private ContactList(Dictionary<string, IContact> contacts)
        {
            _contacts = contacts;
        }

        public IEnumerable<IContact> Contacts { get; } // had to add to iplement Icontact
        
       // public Dictionary<string, Contact> MyContacts { get; set; }

        public int Count => _contacts.Values.Count;

        public ContactList()
        {
            _contacts = new Dictionary<string,IContact>();
        }

        public Dictionary<string, IContact> GetAllContacts => _contacts;

        public IContact GetContact(string username)
        {
            if (_contacts.ContainsKey(username))
                return _contacts[username];
            else
                return null;
        }

        public void AddContact(Contact c)
        {
            if(!_contacts.ContainsKey(c.Username))
                _contacts.Add(c.Username, c);
        }

        public void RemoveContact(Contact c)
        {
            if (_contacts.ContainsKey(c.Username))
                _contacts.Remove(c.Username);
        }



    }
}
