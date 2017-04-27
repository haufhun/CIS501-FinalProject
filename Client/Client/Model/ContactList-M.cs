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

        public IEnumerable<IContact> Contacts { get; }
    }
    //class ContactList_M
    //{
    //    private Dictionary<string, Contact> _contacts = new Dictionary<string, Contact>();

    //    void AddContact(string name)
    //    {

    //    }

    //    void RemoveContact(string name)
    //    {

    //    }

    //    public void UpdateForm()
    //    {

    //    }
    //}
}
