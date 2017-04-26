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
    public class ContactList : IContactList
    {
        [JsonProperty]
        private Dictionary<string, IContact> _contacts;

        public int Count => _contacts.Values.Count;

        public ContactList()
        {
            _contacts = new Dictionary<string, IContact>();
        }

        [JsonConstructor]
        private ContactList(Dictionary<string, IContact> contacts)
        {
            _contacts = contacts;
        }

        public void Add(Contact c)
        {
            _contacts.Add(c.Username, c);
        }

        public void Remove(string username)
        {
            _contacts.Remove(username);
        }

        public IEnumerable<IContact> GetAllContacts()
        {
            throw new NotImplementedException();
        }

        public IContact GetContact(string username)
        {
            throw new NotImplementedException();
        }

    }
}
