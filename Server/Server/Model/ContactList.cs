using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Server.Model
{
    public interface IContactList
    {
        IEnumerable<IContact> GetAllContacts();
        IContact GetContact(string username);
    }
    [JsonObject(MemberSerialization.OptIn)]
    public class ContactList : IContactList
    {
        [JsonProperty]
        private Dictionary<string, IContact> _contacts;

        public ContactList()
        {
            _contacts = new Dictionary<string, IContact>();
        }

        [JsonConstructor]
        private ContactList(Dictionary<string, IContact> contacts)
        {
            _contacts = contacts;
        }

        public void RemoveContact(string username)
        {
            throw new NotImplementedException();
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
